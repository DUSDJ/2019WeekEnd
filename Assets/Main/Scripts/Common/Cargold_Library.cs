using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.UI;

// 0.3.02 Version (2019. 11. 30)

// Extenstion Method    
public static class Cargold_Library
{
    #region Animation Group
    public static void Play_Func(this Animation _anim, AnimationClip _clip, bool _isRewind = false, bool _isImmediatly = false, float _speed = 1f)
    {
        string _clipName = _clip.name;

        _anim.Play_Func(_clipName, _isRewind, _isImmediatly, _speed);
    }
    public static void Play_Func(this Animation _anim, string _clipName, bool _isRewind = false, bool _isImmediatly = false, float _speed = 1f)
    {
        // _isImmediatly를 사용할 경우 애니메이션 이벤트 함수는 작동 안 됨

        if (_anim != null)
        {
            AnimationClip _clip = _anim.GetClip(_clipName);
            if (_clip != null)
            {
                float _time = 0f;

                if (_isImmediatly == false)
                {
                    if (_isRewind == false)
                    {
                        _time = 0f;
                    }
                    else
                    {
                        _speed *= -1f;

                        _time = _anim[_clipName].length;
                    }
                }
                else
                {
                    _speed = 0f;

                    if (_isRewind == false)
                    {
                        _time = _anim[_clipName].length;
                    }
                    else
                    {
                        _time = 0f;
                    }
                }

                _anim[_clipName].speed = _speed;
                _anim[_clipName].time = _time;
                _anim.Play(_clipName);
            }
            else
            {
                throw new Exception("애니메이션 클립이 없습니다. : " + _clipName);
            }
        }
        else
        {
            throw new Exception("애니메이션 컴포넌트가 비어있습니다. : " + _anim.gameObject.name);
        }
    }
    #endregion
    #region Array Group
    public static bool Contatin_Func(this string[] _arr, string _value, CL_ArrayContainSearchType _type = CL_ArrayContainSearchType.StartIndexToBegin)
    {
        // 배열에 특정 값이 있는지 확인
        
        if (_type == CL_ArrayContainSearchType.StartIndexToBegin)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] == _value)
                {
                    return true;
                }
            }
        }
        else if (_type == CL_ArrayContainSearchType.StartIndexToEnd)
        {
            for (int i = _arr.Length - 1; 0 <= i; i--)
            {
                if (_arr[i] == _value)
                {
                    return true;
                }
            }
        }
        else
        {

        }

        return false;
    }
    public enum CL_ArrayContainSearchType
    {
        StartIndexToBegin,
        StartIndexToEnd,
    }
    public static T GetLastItem_Func<T>(this T[] _arr)
    {
        return _arr[_arr.Length - 1];
    }
    public static T GetRandItem_Func<T>(this T[] _arr)
    {
        int _temp = 0;
        return _arr.GetRandItem_Func(out _temp);
    }
    public static T GetRandItem_Func<T>(this T[] _arr, int _startIndex = 0, int _lastIndex = -1)
    {
        int _temp = 0;
        return _arr.GetRandItem_Func(out _temp, _startIndex, _lastIndex);
    }
    public static T GetRandItem_Func<T>(this T[] _arr, out int _randID, int _startIndex = 0, int _lastIndex = -1)
    {
        if (_arr == null)
        {
            throw new Exception("배열이 비어있습니다.");
        }
        else
        {
            if (1 < _arr.Length)
            {
                if (_lastIndex == -1)
                    _lastIndex = _arr.Length;

                _randID = UnityEngine.Random.Range(_startIndex, _lastIndex);

                T _randItem = _arr[_randID];

                return _randItem;
            }
            else
            {
                _randID = 0;

                return _arr[0];
            }
        }
    }
    public static T[] GetRandomPick_Func<T>(this T[] _arr, int _pickNum)
    {
        if (_pickNum < _arr.Length)
        {
            T[] _valueTypeArr = new T[_pickNum];

            for (int i = 0; i < _pickNum; i++)
            {
                int _randomPickIndex = UnityEngine.Random.Range(0, _arr.Length - i);
                _valueTypeArr[i] = _arr[_randomPickIndex];

                _arr.Swap_Func(_randomPickIndex, _arr.Length - i - 1);
            }

            return _valueTypeArr;
        }
        else if (_pickNum == _arr.Length)
        {
            return _arr;
        }
        else
        {
            Debug.LogError("_pickNum : " + _pickNum);
            Debug.LogError("_arr.Length : " + _arr.Length);
            throw new Exception("RandomPick 숫자에 비해 List의 Item 개수가 부족합니다.");
        }
    }

    // 이거 밸류 타입도 문제 없는지 확인 필요함
    public static void Swap_Func<T>(this T[] _arr, int _swapIndex1, int _swapIndex2)
    {
        if(_swapIndex1 != _swapIndex2)
        {
            if (_swapIndex1 < _arr.Length && _swapIndex2 < _arr.Length && 0 <= _swapIndex1 && 0 <= _swapIndex2)
            {
                T _temp = _arr[_swapIndex1];
                _arr[_swapIndex1] = _arr[_swapIndex2];
                _arr[_swapIndex2] = _temp;
            }
            else
            {
                throw new Exception("Swap하려는 배열의 크기는 " + _arr.Length + ". 하지만 접근하려는 Index는 " + _swapIndex1 + ", 그리고 " + _swapIndex2);
            }
        }
        else
        {
            
        }
    }
    #endregion
    #region Casting Group
    // String
    public static T ToEnum<T>(this string value)
    {
        return (T)System.Enum.Parse(typeof(T), value, true);
    }
    public static int ToInt(this string value)
    {
        if (value == "") return 0;

        return System.Int32.Parse(value);
    }
    public static float ToFloat(this string value)
    {
        if (value == "") return 0f;

        float returnValue = 0f;

        System.Single.TryParse(value, out returnValue);

        return returnValue;
    }
    public static Double ToDouble(this string value)
    {
        if (value == "") return 0d;

        double returnValue = 0d;

        System.Double.TryParse(value, out returnValue);

        return returnValue;
    }
    public static bool ToBool(this string value)
    {
        switch (value)
        {
            case "True":
            case "TRUE":
            case "T":
            case "1":
                return true;

            default:
                return false;
        }
    }
    public static Byte ToByte(this string value)
    {
        if (value == "") return 0;

        Byte returnValue = 0;

        System.Byte.TryParse(value, out returnValue);

        return returnValue;
    }

    // Enum
    public static int ToInt(this System.Enum value)
    {
        // 이거 GC 발생한다고 함

        var _returnValue = Convert.ChangeType(value, typeof(int));
        return (int)_returnValue;
    }

    // Float
    public static int ToInt(this float value)
    {
        return (int)value;
    }
    public static string ToString_Func(this float _value, int _pointNumber = 0)
    {
        if (0 < _pointNumber)
        {
            if (_pointNumber == 1)
            {
                return string.Format("{0:N1}", _value);
            }
            else if (_pointNumber == 2)
            {
                return string.Format("{0:N2}", _value);
            }
            else if (_pointNumber == 3)
            {
                return string.Format("{0:N3}", _value);
            }
            else
            {
                // 부동소수점의 오차범위
                // 4자리수 넘어서까지 쓸 일 있으면 추가 바람

                return string.Format("{0:N4}", _value);
            }
        }
        else
        {
            return string.Format("{0:N0}", _value);
        }
    }

    // TimeSpan
    public static string ToString_Func(this TimeSpan _value, bool _isHideHour = false, bool _isContainHourInMinute = true)
    {
        if (_isHideHour == false)
            return string.Format("{0:00}:{1:00}:{2:00}", _value.Hours, _value.Minutes, _value.Seconds);
        else
        {
            if (_isContainHourInMinute == true)
            {
                return string.Format("{0:00}:{1:00}", _value.Minutes + (_value.Hours * 60), _value.Seconds);
            }
            else
            {
                return string.Format("{0:00}:{1:00}", _value.Minutes, _value.Seconds);
            }
        }
    }
    #endregion
    #region Dictionary Group
    public static Dictionary<KeyType, ValueType> SetInstance_NoGC_EnumKey_Func<KeyType, ValueType>(IEqualityComparer<KeyType> _iEqualityComparer)
    {
        return new Dictionary<KeyType, ValueType>(_iEqualityComparer);
    }
    /*
     *  예제 코드
    class Test : IEqualityComparer<EnumType>
    {
        public bool Equals(EnumType x, EnumType y)
        {
            return x == y;
        }

        public int GetHashCode(EnumType obj)
        {
            return (int)obj;
        }
    }
    */
    public static void Add_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, KeyType _addKey, ValueType _addValue)
    {
        // 오류 검출용

        if (_dic.ContainsKey(_addKey) == false)
        {
            _dic.Add(_addKey, _addValue);
        }
        else
        {
            throw new Exception("Dictionary에 다음 Key가 이미 존재합니다. : " + _addKey);
        }
    }
    public static void Remove_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, KeyType _removeKey)
    {
        // 오류 검출용

        if (_dic.ContainsKey(_removeKey) == true)
        {
            _dic.Remove(_removeKey);
        }
        else
        {
            throw new Exception("Dictionary에 지우려고 하는 다음 Key가 존재하지 않습니다. : " + _removeKey);
        }
    }
    public static bool TryRemove_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, KeyType _key, out ValueType _value)
    {
        // 오류 검출용

        if (_dic.TryGetValue(_key, out _value) == true)
        {
            _dic.Remove(_key);

            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetClearToValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _clearDic, ValueType _clearValue)
    {
        // 함수의 Value 인자로 모두 채우기

        int _keyNum = _clearDic.Keys.Count;
        KeyType[] _keyTypeArr = new KeyType[_keyNum];
        _clearDic.Keys.CopyTo(_keyTypeArr, 0);

        for (int i = 0; i < _keyNum; i++)
        {
            KeyType _keyType = _keyTypeArr[i];

            _clearDic[_keyType] = _clearValue;
        }
    }
    public static void SetClearToValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType[]> _clearDic, ValueType _clearValue)
    {
        // 함수의 Value 인자로 모두 채우기

        int _keyNum = _clearDic.Keys.Count;
        KeyType[] _keyTypeArr = new KeyType[_keyNum];
        _clearDic.Keys.CopyTo(_keyTypeArr, 0);

        for (int i = 0; i < _keyNum; i++)
        {
            KeyType _keyType = _keyTypeArr[i];

            int _valueNum = _clearDic[_keyType].Length;
            for (int j = 0; j < _valueNum; j++)
            {
                _clearDic[_keyType][j] = _clearValue;
            }
        }
    }

    public static ValueType GetValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, KeyType _key)
    {
        // Key에 해당하는 Value 반환
        // 오류 검출용

        ValueType _returnValue;
        if (_dic.TryGetValue(_key, out _returnValue) == true)
        {
            return _returnValue;
        }
        else
        {
            throw new System.Exception("Key 없음 : " + _key);
        }
    }
    public static ValueType[] GetValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, params KeyType[] _keyArr)
    {
        // Key에 해당하는 Value 반환
        // 오류 검출용
        // 인자 Key 중 중복Key가 있는지 검사하는 기능도 추가하자

        List<ValueType> _list = new List<ValueType>();

        for (int i = 0; i < _keyArr.Length; i++)
        {
            ValueType _value = _dic.GetValue_Func(_keyArr[i]);
            _list.Add(_value);
        }

        return _list.ToArray();
    }
    public static ValueType[] GetValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic)
    {
        // 딕셔너리의 모든 Value를 배열로 반환

        ValueType[] _returnValueArr = new ValueType[_dic.Values.Count];

        _dic.Values.CopyTo(_returnValueArr, 0);

        return _returnValueArr;
    }
    public static void GetValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, Action<ValueType> _del)
    {
        foreach (KeyValuePair<KeyType, ValueType> item in _dic)
        {
            ValueType _value = item.Value;
            if (_value != null) _del(_value);
        }
    }
    public static ValueType GetValueRandom_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic)
    {
        // 최적화 필요하므로 자주 사용하지 말 것

        ValueType[] _valueAll = Cargold_Library.GetValue_Func<KeyType, ValueType>(_dic);

        int _randValue = UnityEngine.Random.Range(0, _valueAll.Length);

        return _valueAll[_randValue];
    }
    public static KeyType[] GetKeys_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic)
    {
        // 딕셔너리에 입력된 모든 Key를 반환한다.

        KeyType[] _keyTypeArr = new KeyType[_dic.Keys.Count];
        _dic.Keys.CopyTo(_keyTypeArr, 0);
        return _keyTypeArr;
    }
    public static ValueType[] GetValueRandom_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, int _returnNum)
    {
        // 최적화 필요하므로 자주 사용하지 말 것
        // 중복 Value가 Return될 수도 있음

        ValueType[] _valueAll = Cargold_Library.GetValue_Func<KeyType, ValueType>(_dic);
        List<ValueType> _valueList = new List<ValueType>();
        for (int i = 0; i < _returnNum; i++)
        {
            int _randValue = UnityEngine.Random.Range(0, _valueAll.Length);
            _valueList.Add(_valueAll[_randValue]);
        }

        return _valueList.ToArray();
    }

    public static ValueType ReplaceValue_Func<KeyType, ValueType>(this Dictionary<KeyType, ValueType> _dic, KeyType _key, ValueType _value)
    {
        // 신규 Value를 삽입하고 기존 Value는 Dictionary에서 제거 후 반환한다.

        ValueType _originalValue = _dic.GetValue_Func(_key);
        _dic.Remove(_key);
        _dic.Add(_key, _value);
        return _originalValue;
    }
    #endregion
    #region List Group
    public static void AddNewItem_Func<ValueType>(this List<ValueType> _list, ValueType _addItem)
    {
        bool _isContain = _list.Contains(_addItem);

        if (_isContain == false)
        {
            
        }
        else
        {
            Debug.LogWarning("이미 삽입되어 있는 Item을 중복해서 삽입하였습니다. : " + _addItem);
        }

        _list.Add(_addItem);
    }
    public static void AddNewItem_Func<ValueType>(this List<ValueType> _list, ValueType[] _addItemArr)
    {
        for (int i = 0; i < _addItemArr.Length; i++)
        {
            _list.AddNewItem_Func(_addItemArr[i]);
        }
    }
    public static bool InsertNewItem_Func<ValueType>(this List<ValueType> _list, int _id, ValueType _addItem)
    {
        bool _isContain = _list.Contains(_addItem);

        if (_isContain == false)
        {

        }
        else
        {
            Debug.LogWarning("이미 삽입되어 있는 Item을 중복해서 삽입하였습니다. : " + _addItem);
        }

        _list.Insert(_id, _addItem);

        return _isContain;
    }
    public static void Remove_Func<ValueType>(this List<ValueType> _list, ValueType _removeItem)
    {
        if (_list.Contains(_removeItem) == true)
        {
            _list.Remove(_removeItem);
        }
        else
        {
            throw new Exception("존재하지 않는 Item을 Remove하고자 합니다. : " + _removeItem);
        }
    }
    public static ValueType[] GetRandomPick_Func<ValueType>(this List<ValueType> _list, int _pickNum)
    {
        // ToArray()의 퍼포먼스를 고려해서 사용할 것!
        return _list.ToArray().GetRandomPick_Func(_pickNum);
    }
    public static ValueType GetLastItem_Func<ValueType>(this List<ValueType> _list)
    {
        // 리스트의 마지막 아이템 반환

        int _count = _list.Count;
        return _list[_count - 1];
    }
    public static ValueType GetHalfItem_Func<ValueType>(this List<ValueType> _list)
    {
        // 리스트의 중간에 배치된 아이템 반환

        int _listNum = _list.Count;

        int _halfID = _listNum / 2;

        ValueType _halfItem = _list[_halfID];

        return _halfItem;
    }
    public static ValueType GetRandItem_Func<ValueType>(this List<ValueType> _list)
    {
        int _cnt = _list.Count;
        int _randValue = UnityEngine.Random.Range(0, _cnt);
        return _list[_randValue];
    }
    #endregion
    #region Math Group
    public static Quaternion GetLookAt_Func(Vector3 _thisPos, Vector3 _targetPos)
    {
        float angle = _thisPos.GetAngle_Func(_targetPos) * -1f;

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0f, 0f, angle);
        return rotation;
    }

    public static Vector3 GetBezier_Func(Vector3 _startPos, Vector3 _curvePos, Vector3 _arrivePos, float _time)
    {
        var omt = 1f - _time;
        return _startPos * omt * omt + 2f * _curvePos * omt * _time + _arrivePos * _time * _time;
    }
    public static Vector2 GetBezier_Func(Vector2 _startPos, Vector2 _curvePos, Vector2 _arrivePos, float _time)
    {
        var omt = 1f - _time;
        return _startPos * omt * omt + 2f * _curvePos * omt * _time + _arrivePos * _time * _time;
    }

    // 원의 중심에서 _angle에 해당하는 원 둘레의 좌표 얻어오기
    public static Vector2 GetCircumferencePos_Func(this Vector3 _circleCenterPos, float _radius, float _angle)
    {
        return ((Vector2)_circleCenterPos).GetCircumferencePos_Func(_radius, _angle);
    }
    public static Vector2 GetCircumferencePos_Func(this Vector2 _circleCenterPos, float _radius, float _angle)
    {
        float _calcAngle = (_angle * -1f + 90f) * Mathf.Deg2Rad;
        float _cos = _radius * Mathf.Cos(_calcAngle);
        float _sin = _radius * Mathf.Sin(_calcAngle);

        return _circleCenterPos += new Vector2(_cos, _sin);
    }
    
    public static ReturnValue Random_Func<ReturnValue>(params ReturnValue[] _randValueArr)
    {
        return _randValueArr.GetRandItem_Func();
    }
    #endregion
    #region Transform Group
    // 2D용
    public static void LookAt_Func(this Transform _thisTrf, Transform _targetTrf)
    {
        _thisTrf.LookAt_Func(_targetTrf.position);
    }
    public static void LookAt_Func(this Transform _thisTrf, Vector2 _targetPos)
    {
        _thisTrf.rotation = Cargold_Library.GetLookAt_Func(_thisTrf.position, _targetPos);
    }
    public static float GetAngle_Func(this Transform _thisTrf, Vector2 _targetPos)
    {
        return _thisTrf.position.GetAngle_Func(_targetPos);
    }
    
    public static void SetPosX_Func(this Transform _thisTrf, float _value, UnityEngine.Space _space)
    {
        if (_space == Space.World)
        {
            _thisTrf.position = new Vector3(_value, _thisTrf.position.y, _thisTrf.position.z);
        }
        else
        {
            _thisTrf.localPosition = new Vector3(_value, _thisTrf.localPosition.y, _thisTrf.localPosition.z);
        }
    }
    public static void SetPosY_Func(this Transform _thisTrf, float _value, UnityEngine.Space _space = Space.World)
    {
        if (_space == Space.World)
        {
            _thisTrf.position = new Vector3(_thisTrf.position.x, _value, _thisTrf.position.z);
        }
        else
        {
            _thisTrf.localPosition = new Vector3(_thisTrf.localPosition.x, _value, _thisTrf.localPosition.z);
        }
    }
    public static void SetPosZ_Func(this Transform _thisTrf, float _value, UnityEngine.Space _space)
    {
        if (_space == Space.World)
        {
            _thisTrf.position = new Vector3(_thisTrf.position.x, _thisTrf.position.y, _value);
        }
        else
        {
            _thisTrf.localPosition = new Vector3(_thisTrf.localPosition.x, _thisTrf.localPosition.y, _value);
        }
    }
    #endregion
    #region UGUI Group
    public static void SetFade_Func(this SpriteRenderer _spriteRend, float _alphaValue)
    {
        Color _returnColor = _spriteRend.color;

        _spriteRend.color = GetNaturalAlphaColor_Func(_returnColor, _alphaValue);
    }
    public static void SetFade_Func(this Image _image, float _alphaValue)
    {
        Color _returnColor = _image.color;

        _image.color = GetNaturalAlphaColor_Func(_returnColor, _alphaValue);
    }
    public static void SetFade_Func(this Text _text, float _alphaValue)
    {
        Color _returnColor = _text.color;

        _text.color = GetNaturalAlphaColor_Func(_returnColor, _alphaValue);
    }
    public static void SetFade_Func(this Graphic _graphic, float _alphaValue)
    {
        Color _returnColor = _graphic.color;

        _graphic.color = GetNaturalAlphaColor_Func(_returnColor, _alphaValue);
    }

    public static Color GetNaturalAlphaColor_Func(this Color _color, float _alphaValue)
    {
        Color _returnColor = new Color
            (
            _color.r,
            _color.g,
            _color.b,
            _alphaValue
            );

        return _returnColor;
    }
    public static void SetAlphaOnBaseColor_Func(this Color _color, float _alphaValue)
    {
        Color _setColor = new Color
            (
            _color.r,
            _color.g,
            _color.b,
            _alphaValue
            );

        _color = _setColor;
    }
    public static void SetColorOnBaseAlpha_Func(this Image _image, Color _setColor)
    {
        _setColor = new Color
            (
            _setColor.r,
            _setColor.g,
            _setColor.b,
            _image.color.a
            );

        _image.color = _setColor;
    }
    public static void SetNativeSize_Func(this Image _image, Sprite _sprite)
    {
        _image.sprite = _sprite;
        _image.SetNativeSize();
    }

    public static void FillAmount_Func(this Image _image, int _setValue, int _maxValue)
    {
        _image.FillAmount_Func((float)_setValue, (float)_maxValue);
    }
    public static void FillAmount_Func(this Image _image, float _setValue, int _maxValue)
    {
        _image.FillAmount_Func(_setValue, (float)_maxValue);
    }
    public static void FillAmount_Func(this Image _image, int _setValue, float _maxValue)
    {
        _image.FillAmount_Func((float)_setValue, _maxValue);
    }
    public static void FillAmount_Func(this Image _image, float _setValue, float _maxValue)
    {
        if (0f < _setValue && 0f < _maxValue)
            _image.fillAmount = _setValue / _maxValue;
        else
            _image.fillAmount = 0f;
    }

    public static void SetText_Func(this Text _txt, int _value)
    {
        _txt.text = _value.ToString();
    }
    public static void SetText_Func(this Text _txt, float _value, int _digitNum = -1)
    {
        if(_digitNum == -1)
        {
            _txt.text = _value.ToString();
        }
        else
        {
            _txt.text = _value.ToString_Func(_digitNum);
        }
    }

    public static void SetText_Func(this TMPro.TextMeshProUGUI _tmp, int _value)
    {
        _tmp.text = _value.ToString();
    }
    public static void SetText_Func(this TMPro.TextMeshPro _tmp, int _value)
    {
        _tmp.text = _value.ToString();
    }
    #endregion
    #region Data Structure
    public static bool HasItem_Func<T>(this Queue<T> _queue)
    {
        return 0 < _queue.Count ? true : false;
    }
    public static bool Dequeue_Func<T>(this Queue<T> _queue, out T _tryGet)
    {
        bool _isHave = false;

        if (0 < _queue.Count)
        {
            _isHave = true;

            _tryGet = _queue.Dequeue();
        }
        else
        {
            _isHave = false;

            _tryGet = default(T);
        }

        return _isHave;
    }
    #endregion
    #region StringBuilder
    public static void RemoveAll_Func(this StringBuilder _stringBuilder)
    {
        _stringBuilder.Remove(0, _stringBuilder.Length);
    }
    #endregion
    #region Vector
    public static bool CheckInside_Func(this Vector2 _targetPos, Vector2 _spaceMinPos, Vector2 _spaceMaxPos)
    {
        if (_spaceMinPos.x <= _targetPos.x && _targetPos.x <= _spaceMaxPos.x
        && _spaceMinPos.y <= _targetPos.y && _targetPos.y <= _spaceMaxPos.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool CheckInside_Func(this Vector2 _targetPos, Transform _spaceMinTrf, Transform _spaceMaxTrf)
    {
        return CheckInside_Func(_targetPos, _spaceMinTrf.position, _spaceMaxTrf.position);
    }

    public static bool CheckClose_Func(this Vector2 _thisPos, Transform _targetTrf, float _distance)
    {
        return _thisPos.CheckClose_Func(_targetTrf.position, _distance);
    }
    public static bool CheckClose_Func(this Vector2 _thisPos, Vector2 _targetPos, float _distance)
    {
        return Vector2.Distance(_thisPos, _targetPos) <= _distance;
    }

    // 두 좌표 사이에 각도 구하기
    public static float GetAngle_Func(this Vector3 _thisPos, Vector3 _targetPos)
    {
        return GetAngle_Func((Vector2)_thisPos, (Vector2)_targetPos);
    }
    public static float GetAngle_Func(this Vector2 _thisPos, Vector2 _targetPos)
    {
        Vector2 _normalTangent = _targetPos - _thisPos;
        _normalTangent.Normalize();

        float angle = Mathf.Atan2(_normalTangent.x, _normalTangent.y) * Mathf.Rad2Deg;

        return 0f <= angle ? angle : 360f + angle;
    }
    public static Vector2 GetRight_Func(this Vector2 _thisPos, float _value)
    {
        return new Vector2(_thisPos.x + _value, _thisPos.y);
    }
    public static Vector2 GetUp_Func(this Vector2 _thisPos, float _value)
    {
        return new Vector2(_thisPos.x, _thisPos.y + _value);
    }

    public static Vector2 GetRandX_Func(this Vector2 _thisPos, float _minX, float _maxX)
    {
        return new Vector2(UnityEngine.Random.Range(_minX, _maxX), _thisPos.y);
    }
    public static Vector2 GetRandY_Func(this Vector2 _thisPos, float _minY, float _maxY)
    {
        return new Vector2(_thisPos.x, UnityEngine.Random.Range(_minY, _maxY));
    }
    public static Vector2 GetRand_Func(this Vector2 _thisPos, float _minX, float _maxX, float _minY, float _maxY)
    {
        return new Vector2(UnityEngine.Random.Range(_minX, _maxX), UnityEngine.Random.Range(_minY, _maxY));
    }
    #endregion
}

// Utility Class
#region Singleton
namespace Cargold.Singleton
{
    public abstract class Singleton_C<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance != null)
                {

                }
                else
                {
                    Generate_Func();
                }

                return instance;
            }
        }

        // 싱글턴을 사용하기 위해 아래의 함수를 최초 1회 호출해야 함.
        // 미호출 시 Property를 통해 예외처리하므로 문제는 없으나 Warning Log는 출력됨.

        public static void Generate_Func()
        {
            T _singletonComponent = FindObjectOfType<T>();

            Singleton_C<T>.Generate_Func(_singletonComponent);
        }
        public static void Generate_Func(T _existenceComonent)
        {
            GameObject _singletonObj = null;

            if (_existenceComonent != null)
            {
                _singletonObj = _existenceComonent.gameObject;

                instance = _existenceComonent;
            }
            else
            {
                Debug.LogWarning("싱글턴 객체를 동적 생성하였습니다. 따라서 Data Initialize를 고려해주시기 바랍니다. - " + typeof(T));

                _singletonObj = new GameObject();
                instance = _singletonObj.AddComponent<T>();
                _singletonObj.name = StringBuilder_C.Append_Func("(Singleton)", typeof(T).ToString());
            }
        
            UnityEngine.Object.DontDestroyOnLoad(_singletonObj);
        }
    }

    public abstract class Singleton_Cor<T> : Singleton_C<T> where T : MonoBehaviour
    {
        public abstract IEnumerator Init_Cor();
    }
    public abstract class Singleton_Func<T> : Singleton_C<T> where T : MonoBehaviour
    {
        public abstract void Init_Func();
    }
}
#endregion
#region Observer
namespace Cargold.Observer
{
    // 구독자 관리 클래스
    public class Observer_Manager<SubscriberType>
    {
        protected List<SubscriberType> subscriberList;

        public Observer_Manager()
        {
            subscriberList = new List<SubscriberType>();
        }
        
        // 구독
        public bool Subscribe_Func(SubscriberType _subscriber, int _insertID = -1, bool _isEnableOverlap = false)
        {
            bool _isContainListener = subscriberList.Contains(_subscriber);

            bool _isAddable = true;
            if (_isEnableOverlap == false)
            {
                if (_isContainListener == false)
                {

                }
                else
                {
                    _isAddable = false;

                    Debug_C.Warning_Func("중복 구독 : " + _subscriber);
                }
            }
            else
            {

            }

            if (_isAddable == true)
            {
                if (_insertID == -1)
                    subscriberList.Add(_subscriber);
                else
                    subscriberList.Insert(_insertID, _subscriber);
            }

            return _isContainListener;
        }

        // 구독 전체 해지
        public bool RemoveAll_Func()
        {
            // 구독 전체 해제
            // 구독자가 있는가?

            if (0 < subscriberList.Count)
            {
                subscriberList.Clear();

                return true;
            }
            else
            {
                return false;
            }
        }

        // 특정 구독자만 해지
        public bool Remove_Func(SubscriberType _subscriber)
        {
            if (this.subscriberList.Contains(_subscriber) == true)
            {
                this.subscriberList.Remove(_subscriber);

                return true;
            }
            else
            {
                Debug_C.Warning_Func("해지할 대상이 애초에 구독하고 있지 않음 : " + _subscriber);

                return false;
            }
        }

        // 특정 구독자의 구독 여부
        public bool CheckSubscriber_Func(SubscriberType _subscriber)
        {
            return this.subscriberList.Contains(_subscriber);
        }

        // 구독자 숫자
        public int GetSubscriberNum_Func()
        {
            return this.subscriberList.Count;
        }

        public bool HasSubscriber { get { return 0 < this.subscriberList.Count ? true : false; } }

        // 모든 구독자에게 접근
        public void AccessWholeSubscriber_Func(Action<SubscriberType> _del)
        {
            foreach (SubscriberType _subscriber in this.subscriberList)
                _del(_subscriber);
        }
    }
    #region Action 0
    public class Observer_Action : Observer_Manager<Action>
    {
        public bool Notify_Func()
        {
            // 등록된 모든 구독자에게 알림
            // 구독자가 있는지 확인

            if (0 < subscriberList.Count)
            {
                for (int i = 0; i < subscriberList.Count; i++)
                {
                    subscriberList[i]();
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region Action 1
    public class Observer_Action<T> : Observer_Manager<Action<T>>
    {
        public bool Notify_Func(T _t)
        {
            // 등록된 모든 구독자에게 알림
            // 구독자가 있는지 확인

            if (0 < subscriberList.Count)
            {
                for (int i = 0; i < subscriberList.Count; i++)
                {
                    subscriberList[i](_t);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region Action 2
    public class Observer_Action<T1, T2> : Observer_Manager<Action<T1, T2>>
    {
        public bool Notify_Func(T1 _t1, T2 _t2)
        {
            // 등록된 모든 구독자에게 알림
            // 구독자가 있는지 확인

            if (0 < subscriberList.Count)
            {
                for (int i = 0; i < subscriberList.Count; i++)
                {
                    subscriberList[i](_t1, _t2);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region Action 3
    public class Observer_Action<T1, T2, T3> : Observer_Manager<Action<T1, T2, T3>>
    {
        public bool Notify_Func(T1 _t1, T2 _t2, T3 _t3)
        {
            // 등록된 모든 구독자에게 알림
            // 구독자가 있는지 확인

            if (0 < subscriberList.Count)
            {
                for (int i = 0; i < subscriberList.Count; i++)
                {
                    subscriberList[i](_t1, _t2, _t3);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
}
#endregion
#region Which One
namespace Cargold.WhichOne
{
    public sealed class WhichOne<T> where T : class, IWhichOne
    {
        private T whichOne;

        public WhichOne()
        {
            whichOne = null;
        }
        public void Selected_Func(T _whichOne)
        {
            // 인자값을 선택 개체로 등록하고 '선택'이벤트 전달.
            // 만약 기 개체를 선택한 경우 선택 개체에게 중복 선택임을 알림
            // 만약 이미 선택 개체가 있다면, 기 선택 개체에게 '선택 해제'이벤트 전달

            if (this.whichOne == null)
            {
                this.whichOne = _whichOne;

                _whichOne.Selected_Func();
            }
            else
            {
                if (this.whichOne == _whichOne)
                {
                    _whichOne.Selected_Func(true);
                }
                else
                {
                    this.whichOne.SelectCancel_Func();

                    this.whichOne = _whichOne;

                    _whichOne.Selected_Func();
                }
            }
        }
        public void SelectCancel_Func()
        {
            // 선택 해제. 선택 개체에게 선택 해제 이벤트 알림

            if (this.whichOne != null)
            {
                this.whichOne.SelectCancel_Func();

                this.whichOne = null;
            }
            else
            {

            }
        }
        public T GetWhichOne_Func()
        {
            // 선택 개체 반환

            return this.whichOne;
        }
        public void SetWhichOne_Func(T _iWhichOne)
        {
            this.whichOne = _iWhichOne;
        }
        public bool Compare_Func(T _check)
        {
            // 인자값과 선택 개체가 동일한가?

            return this.whichOne == _check;
        }
        public bool HasWhichOne_Func()
        {
            // 선택한 개체가 있는가?

            if (this.whichOne == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearWhichOne_Func()
        {
            this.whichOne = null;
        }
    }

    public interface IWhichOne
    {
        void Selected_Func(bool _repeat = false); // 선택됨
        void SelectCancel_Func(); // 선택 해제됨
    }

    // 1. 선택 순서를 기록하고 이를 역행하면서 선택 해제하고 싶다면?
    /*
     * List를 써서 순서 기록
     * 순서를 역순으로 돌아갈 수 있음
     * List Clear 시점은 Select 값이 없을 때?
     */

    // 2. 선택 개수를 2개 이상인 경우엔?
    /*
     * 선택 개수를 초과할 경우 가장 먼저 선택된 객체가 해제?
     */
}
#endregion
#region Tile System
namespace Cargold.TileSystem
{
    // 사용법
    // 타일을 통제할 매니저는 TileSystem_Class를 상속 받아야 한다.
    // T에는 한 타일에 올라올 수 있는 Type이다.

    // 타일 매니저에 관리 당할 일반 타일 클래스는 Tile_Class를 상속 받아야 한다.
    // 타일 매니저와 일반 타일 클래스는 모두 초기화 함수(Init_Func)을 호출해야 한다.
    // 타일 클래스는 타일 매니저에게 관리를 받기 위해선 SetTile 함수를 호출해야 한다.

    public abstract class TileSystem_Class<T> : MonoBehaviour
    {
        protected TileGroup_Class<T>[,] tileGroupClassArr;
        public int FieldSizeX_Max { get { return tileGroupClassArr.GetLength(0); } }
        public int FieldSizeY_Max { get { return tileGroupClassArr.GetLength(1); } }
        public TilePosData FieldSize_Max { get { return new TilePosData(FieldSizeX_Max, FieldSizeY_Max); } }

        // 타일맵 시스템의 시작 WorldSpace위치 보정값
        public virtual Vector2 TilePos_InitData { get { return new Vector2(0, 0); } }

        // 각 타일간의 WorldSpace 간격
        public virtual Vector2 TileSpace { get { return new Vector2(1, 1); } }

        // 초기화
        protected virtual void Init_Func(int _x, int _y)
        {
            tileGroupClassArr = new TileGroup_Class<T>[_x, _y];

            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    tileGroupClassArr[x, y] = new TileGroup_Class<T>(x, y);
                }
            }
        }

        // 특정 타일을 매니저에게 알려서 관리 받도록 세팅
        public void SetTile_Func(Tile_Class<T> _tileClass)
        {
            int _x = _tileClass.TilePosX;
            int _y = _tileClass.TilePosY;

            if (CheckTileRange_Func(_x, _y) == true)
            {
                this.tileGroupClassArr[_x, _y].SetTile_Func(_tileClass);
            }
            else
            {
                throw new Exception("필드의 영역을 벗어났습니다.");
            }
        }
        public void RemoveTile_Func(Tile_Class<T> _tileClass)
        {
            int _x = _tileClass.TilePosX;
            int _y = _tileClass.TilePosY;

            if (CheckTileRange_Func(_x, _y) == true)
            {
                this.tileGroupClassArr[_x, _y].RemoveTile_Func(_tileClass);
            }
            else
            {
                throw new Exception("필드의 영역을 벗어났습니다.");
            }
        }

        // 타일 범위 안에 있는가?
        public bool CheckTileRange_Func(TilePosData _posData)
        {
            return CheckTileRange_Func(_posData.X, _posData.Y);
        }
        public bool CheckTileRange_Func(int _x, int _y)
        {
            if (this.FieldSizeX_Max <= _x || _x < 0)
            {
                Debug_C.Log_Func("Out of tile randge to X : " + _x);
                return false;
            }
            else if (this.FieldSizeY_Max <= _y || _y < 0)
            {
                Debug_C.Log_Func("Out of tile randge to Y : " + _y);
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool GetTile_Func(TilePosData _data, T _type, out Tile_Class<T> _tileClass)
        {
            return this.GetTile_Func(_data.X, _data.Y, _type, out _tileClass);
        }
        public bool GetTile_Func(int _x, int _y, T _type, out Tile_Class<T> _tileClass)
        {
            if (CheckTileRange_Func(_x, _y) == true)
            {
                TileGroup_Class<T> _tileGroupClass = this.tileGroupClassArr[_x, _y];

                return _tileGroupClass.CheckTile_Func(_type, out _tileClass);
            }
            else
            {
                throw new Exception("필드의 영역을 벗어났습니다.");
            }
        }
        public bool[] GetTileArr_Func(TilePosData _posData, out Tile_Class<T>[] _tileClassArr, params T[] _typeArr)
        {
            return GetTileArr_Func(_posData.X, _posData.Y, out _tileClassArr, _typeArr);
        }
        public bool[] GetTileArr_Func(int _x, int _y, out Tile_Class<T>[] _tileClassArr, params T[] _typeArr)
        {
            TileGroup_Class<T> _tileGroupClass = this.tileGroupClassArr[_x, _y];

            bool[] _isReturnArr = new bool[_typeArr.Length];
            _tileClassArr = new Tile_Class<T>[_typeArr.Length];

            for (int i = 0; i < _typeArr.Length; i++)
            {
                _isReturnArr[i] = _tileGroupClass.CheckTile_Func(_typeArr[i], out _tileClassArr[i]);
            }

            return _isReturnArr;
        }

        public bool Move_Func(Tile_Class<T> _moveTileClass, int _arrivePosX, int _arrivePosY, DirectionType _moveDir = DirectionType.None, bool _isJustCheck = false, params T[] _checkTileTypeArr)
        {
            // 이동 좌표가 타일 범위를 초과했는가?
            bool _isTileRange = this.CheckTileRange_Func(_arrivePosX, _arrivePosY);

            if (_isTileRange == true)
            {
                // 이동 타일의 정보
                int _movePosX = _moveTileClass.TilePosX;
                int _movePosY = _moveTileClass.TilePosY;

                // 도착 타일의 정보
                TileGroup_Class<T> _arriveTileGroupClass = this.tileGroupClassArr[_arrivePosX, _arrivePosY];
                Tile_Class<T>[] _arriveTileClassArr = new Tile_Class<T>[_checkTileTypeArr.Length];

                bool _isMovable = false;
                bool[] _isArriveTileHaveArr = new bool[_checkTileTypeArr.Length];

                for (int i = 0; i < _checkTileTypeArr.Length; i++)
                {
                    _isArriveTileHaveArr[i] = _arriveTileGroupClass.CheckTile_Func(_checkTileTypeArr[i], out _arriveTileClassArr[i]);

                    // 도착 지점에 특정 타일이 있는가?
                    if (_isArriveTileHaveArr[i] == true)
                    {
                        // 도착 지점의 특정 타일의 이동 가능 여부 확인
                        _isMovable = _arriveTileClassArr[i].CheckMovable_Func(_moveTileClass);

                        if (_isMovable == true)
                        {

                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        _isMovable = true;
                    }
                }

                // 단순히 확인만 할 것인가?
                if (_isJustCheck == false)
                {
                    // 도착 지점으로 이동 가능한가?
                    if (_isMovable == true)
                    {
                        // 타일 그룹에서 이동 타일을 제외시킴
                        TileGroup_Class<T> _moveTileGroupClass = this.tileGroupClassArr[_movePosX, _movePosY];
                        _moveTileGroupClass.RemoveTile_Func(_moveTileClass);

                        for (int i = 0; i < _isArriveTileHaveArr.Length; i++)
                        {
                            // 도착 지점에 특정 타일이 있는가?
                            if (_isArriveTileHaveArr[i] == true)
                            {
                                // 도착 지점의 특정 타일에게 '밀려남'을 알림
                                _arriveTileClassArr[i].Pushed_Func(_moveTileClass, _moveDir);
                            }
                            else
                            {

                            }
                        }

                        _arriveTileGroupClass.SetTile_Func(_moveTileClass);
                    }
                    else
                    {

                    }
                }
                else
                {

                }

                return _isMovable;
            }
            else
            {
                return false;
            }
        }
        public TileGroup_Class<T> GetTileGroupClass_Func(TilePosData _posData)
        {
            return this.GetTileGroupClass_Func(_posData.X, _posData.Y);
        }
        public TileGroup_Class<T> GetTileGroupClass_Func(int _x, int _y)
        {
            this.CheckTileRange_Func(_x, _y);

            return this.tileGroupClassArr[_x, _y];
        }
    }
    public class TileGroup_Class<T>
    {
        private int xAxis;
        private int yAxis;

        public int XAxis { get { return xAxis; } }
        public int YAxis { get { return yAxis; } }

        private Dictionary<T, Tile_Class<T>> tileGroupDic;

        public TileGroup_Class(int _x, int _y)
        {
            tileGroupDic = new Dictionary<T, Tile_Class<T>>();

            xAxis = _x;
            yAxis = _y;
        }
        public void SetTile_Func(Tile_Class<T> _tileClass)
        {
            T _tileType = _tileClass.TileType;

            if (this.tileGroupDic.ContainsKey(_tileType) == false)
            {
                this.tileGroupDic.Add_Func(_tileType, _tileClass);
            }
            else
            {
                Debug.Log("Set : " + _tileClass.TilePosX + "_" + _tileClass.TilePosY);
                Debug.Log("Type : " + _tileType);
                throw new Exception("다음 Type의 Tile을 추가하려 했으나 이미 동일한 Type의 Tile이 배치되어 있습니다. : " + _tileType);
            }
        }
        public void RemoveTile_Func(Tile_Class<T> _tileClass)
        {
            //Debug.Log("Remove : " + _tileClass.PosX + "_" + _tileClass.PosY);

            T _tileType = _tileClass.TileType;

            if (this.tileGroupDic.ContainsKey(_tileType) == true)
            {
                this.tileGroupDic.Remove_Func(_tileType);
            }
            else
            {
                Debug.Log("Remove : " + _tileClass.TilePosX + "_" + _tileClass.TilePosY);
                Debug.Log("Type : " + _tileType);
                throw new Exception("다음 타입의 타일을 제거하려 했으나 배치되어 있지 않습니다. : " + _tileType);
            }
        }
        public bool CheckTile_Func(T _tileType, out Tile_Class<T> _tileClass)
        {
            return this.tileGroupDic.TryGetValue(_tileType, out _tileClass);
        }
    }
    public abstract class Tile_Class<T> : MonoBehaviour
    {
        protected  TileSystem_Class<T> tileSystemClass;
        protected  int                 tilePosX;
        protected  int                 tilePosY;
        protected  T                   tileType        { get { return this.Init_TileType_Func(); } }
        public     T                   TileType        { get { return this.tileType; } }

        public     int                 TilePosX        { get { return tilePosX; } }
        public     int                 TilePosY        { get { return tilePosY; } }
        public     TilePosData         TilePos         { get { return new TilePosData(tilePosX, tilePosY); } }

        public virtual void Init_Tile_Func(TilePosData _tilePosData, TileSystem_Class<T> _tileSystemClass, bool _isSetTile = true, bool _isSetPos = true)
        {
            this.Init_Tile_Func(_tilePosData.X, _tilePosData.Y, _tileSystemClass, _isSetTile, _isSetPos);
        }
        public virtual void Init_Tile_Func(int _x, int _y, TileSystem_Class<T> _tileSystemClass, bool _isSetTile = true, bool _isSetPos = true)
        {
            this.SetPos_Func(_x, _y);

            this.tileSystemClass = _tileSystemClass;

            if (_isSetTile == true) _tileSystemClass.SetTile_Func(this);
            if(_isSetPos == true) this.Move_Func(_x, _y);
        }
        protected abstract T Init_TileType_Func();
        protected void SetPos_Func(TilePosData _posData)
        {
            this.SetPos_Func(_posData.X, _posData.Y);
        }
        protected void SetPos_Func(int _posX, int _posY)
        {
            this.tilePosX = _posX;
            this.tilePosY = _posY;
        }

        // 이동 가능 여부
        public virtual bool CheckMovable_Func(Tile_Class<T> _moveTileClass)
        {
            return false;
        }

        // 이동을 시도할 경우 호출됨
        protected bool Move_Func(DirectionType _dirType, bool _isJustCheck = false, params T[] _checkTileTypeArr)
        {
            TilePosData _arrivePosData = TilePosData.GetPos_Func(this, _dirType);

            // 이동 시 확인할 타일 종류가 정해져있는가?
            if (0 < _checkTileTypeArr.Length)
            {

            }
            else
            {
                // 위 타일과 동일한 타일 종류를 확인한다.
                _checkTileTypeArr = new T[1] { this.tileType };
            }

            bool _isMovable = tileSystemClass.Move_Func(this, _arrivePosData.X, _arrivePosData.Y, _dirType, _isJustCheck, _checkTileTypeArr);

            // 확인만 하는게 아닌가?
            if (_isJustCheck == false)
            {
                // 이동 가능한가?
                if (_isMovable == true)
                {
                    this.SetPos_Func(_arrivePosData);

                    this.Move_Func(_arrivePosData);
                }
                else
                {
                    this.MoveFail_Func();
                }
            }
            else
            {

            }

            return _isMovable;
        }

        // 이동한 경우 호출됨
        protected virtual void Move_Func(TilePosData _posData)
        {
            this.Move_Func(_posData.X, _posData.Y);
        }
        protected virtual void Move_Func(int _posX, int _posY)
        {
            float _posX_f = _posX * this.tileSystemClass.TileSpace.x;
            float _posY_f = _posY * this.tileSystemClass.TileSpace.y;

            Vector2 _initPos = this.tileSystemClass.TilePos_InitData;
            _posX_f += _initPos.x;
            _posY_f += _initPos.y;

            this.transform.position = new Vector2(_posX_f, _posY_f);
        }

        // 이동에 실패한 경우 호출됨
        protected abstract void MoveFail_Func();

        // 밀려난 경우 호출됨
        public abstract void Pushed_Func(Tile_Class<T> _pushTileClass, DirectionType _pushDir = DirectionType.None);

        public bool CheckTileRange_Func(DirectionType _dirType, out TilePosData _checkPosData, int _times = 1)
        {
            int _checkTilePosX = this.TilePosX;
            int _checkTilePosY = this.TilePosY;

            switch (_dirType)
            {
                case DirectionType.Left:
                    _checkTilePosX -= _times;
                    break;
                case DirectionType.Down:
                    _checkTilePosY -= _times;
                    break;
                case DirectionType.Up:
                    _checkTilePosY += _times;
                    break;
                case DirectionType.Right:
                    _checkTilePosX += _times;
                    break;
            }

            _checkPosData = new TilePosData(_checkTilePosX, _checkTilePosY);

            return this.tileSystemClass.CheckTileRange_Func(_checkTilePosX, _checkTilePosY);
        }

        public virtual void RemoveTile_Func()
        {
            tileSystemClass.RemoveTile_Func(this);
        }
    }

    public enum DirectionType
    {
        Left = -2,
        Down = -1,
        None = 0,
        Up = 1,
        Right = 2,
    }

    [System.Serializable]
    public struct TilePosData
    {
        private int x;
        private int y;

        public TilePosData(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }

        public static TilePosData GetPos_Func<T>(Tile_Class<T> _tileClass, DirectionType _dirType)
        {
            int _x = _tileClass.TilePosX;
            int _y = _tileClass.TilePosY;

            TilePosData _data = TilePosData.GetPos_Func(_x, _y, _dirType);

            return _data;
        }
        public static TilePosData GetPos_Func(TilePosData _posData, DirectionType _dirType)
        {
            return TilePosData.GetPos_Func(_posData.x, _posData.y, _dirType);
        }
        public static TilePosData GetPos_Func(int _x, int _y, DirectionType _dirType)
        {
            switch (_dirType)
            {
                case DirectionType.Up:
                    _y++;
                    break;
                case DirectionType.Right:
                    _x++;
                    break;
                case DirectionType.Down:
                    _y--;
                    break;
                case DirectionType.Left:
                    _x--;
                    break;
            }

            return new TilePosData(_x, _y);
        }
    }
}

// 타일 영역이 실시간으로 커지거나 작아지는 기능 추가
// 
#endregion
#region LayerSorting System
namespace Cargold.LayerSort
{
    using Cargold.TileSystem;

    public abstract class LayerSorting_System<T> : MonoBehaviour
    {
        private Dictionary<T, int> layerGapDic;

        // 타일간 레이어 간격
        private int layerGap;
        protected int LayerGap { get { return layerGap; } }

        public virtual void Init_Func()
        {
            layerGapDic = new Dictionary<T, int>();

            T[] _typeArr = Init_LayerType_Func();

            Init_TileGap_Func(_typeArr);
        }
        protected abstract T[] Init_LayerType_Func();

        // 타일간 레이어 간격값
        private void Init_TileGap_Func(params T[] _typeArr)
        {
            int _typeGap = Init_TypeGap_Func();

            for (int i = 0; i < _typeArr.Length; i++)
            {
                int _keyCount = 0;

                _keyCount = this.layerGapDic.Keys.Count;

                int _layerRangeValue = _typeGap * _keyCount;

                this.layerGapDic.Add_Func(_typeArr[i], _layerRangeValue);

                // 새로운 타입이 추가되었으므로 타일간 레이어 간격도 그만큼 확장한다.
                layerGap += _typeGap;
            }
        }
        // 타입간 레이어 간격값
        // 타입 사이에 많은 레이어 구분이 필요할 경우 재정의하여 값을 10보다 키우면 됨
        protected virtual int Init_TypeGap_Func()
        {
            return 10;
        }

        public void SetLayerSort_Func(SpriteRenderer _spriteRend, T _layerType, TilePosData _posData, int _layerExtraID = 0)
        {
            this.SetLayerSort_Func(_spriteRend, _layerType, _posData.Y, _layerExtraID);
        }
        public void SetLayerSort_Func(SpriteRenderer _spriteRend, T _layerType, Tile_Class<T> _tileClass, int _layerExtraID = 0)
        {
            this.SetLayerSort_Func(_spriteRend, _layerType, _tileClass.TilePosY, _layerExtraID);
        }
        public void SetLayerSort_Func(SpriteRenderer _spriteRend, T _layerType, int _posY, int _layerExtraID = 0)
        {
            int _typeGap = 1;
            if (this.layerGapDic.TryGetValue(_layerType, out _typeGap) == true)
            {

            }
            else
            {
                throw new Exception("다음 타입의 레이어는 초기화되지 않았습니다. : " + _layerType);
            }

            // 스프라이트의 타일 Y값만큼 타일 간격을 곱하여 레이어를 정렬한다.
            int _layerSortID = _posY * this.LayerGap;

            // 스프라이트의 타입만큼 레이어를 조금 더 정렬한다.
            _layerSortID += _typeGap;

            // 임의 레이어값만큼 레이어를 조금 더 정렬한다.
            _layerSortID += _layerExtraID;

            // 정렬값을 역전하여 Y축 값이 작을 수록 레이어가 앞에 나오도록 한다.
            _layerSortID *= -1;

            _spriteRend.sortingOrder = _layerSortID;
        }
    }
}
#endregion
#region ResourceFindPath
namespace Cargold.ResourceFindPath
{
    // ResourceFindPath 상속 받는 클래스에서 경로를 스크립트에 적어놓고 쓰는 거 추천

    public abstract class ResourceFindPath<PathType>
    {
        private Dictionary<PathType, string> pathDic;

        public virtual void Init_Func()
        {
            pathDic = new Dictionary<PathType, string>();
        }

        public void SetPath_Func(PathType _pathType, string _path)
        {
            pathDic.Add_Func(_pathType, _path);
        }

        public T GetResource_Func<T>(PathType _pathType, bool _isDebug = true) where T : UnityEngine.Object
        {
            string _path = this.pathDic.GetValue_Func(_pathType);

            return this.GetResource_Func<T>(_path, _isDebug);
        }

        // 잘 불러와졌는지 체크
        public T GetResource_Func<T>(string _path, bool _isDebug = true) where T : UnityEngine.Object
        {
            T _returnObj = Resources.Load<T>(_path);
            if (_returnObj == null)
            {
                if (_isDebug == true)
                {
                    Debug.LogError("Bug : 데이터 로드 실패");
                    Debug.Log("Path : " + _path);
                }
            }

            return _returnObj;
        }
        public T[] GetResourceAll_Func<T>(PathType _pathType, bool _isDebug = true) where T : UnityEngine.Object
        {
            string _path = this.pathDic.GetValue_Func(_pathType);

            return this.GetResourceAll_Func<T>(_path, _isDebug);
        }

        // 잘 불러와졌는지 체크
        public T[] GetResourceAll_Func<T>(string _path, bool _isDebug = true) where T : UnityEngine.Object
        {
            T[] _returnObjArr = Resources.LoadAll<T>(_path);
            if (_returnObjArr == null)
            {
                if (_isDebug == true)
                {
                    Debug.LogError("Bug : 데이터 로드 실패");
                    Debug.Log("Path : " + _path);
                }
            }

            return _returnObjArr;
        }

        public ComponentType GetComponentByInstantiateObj_Func<ComponentType>(PathType _pathType)
        {
            GameObject _loadObj = this.GetResource_Func<GameObject>(_pathType);
            GameObject _genObj = GameObject.Instantiate(_loadObj);
            
            ComponentType _componentType = _genObj.GetComponent<ComponentType>();

            return _componentType;
        }
    }
}

#endregion
#region Data Structure
namespace Cargold.DataStructure
{
    [System.Serializable]
    public sealed class CirculateQueue<T>
    {
        private List<T> circulateList;
        private int circulateID;
        public T GetItem { get { return this.circulateList[this.circulateID]; } }
        public int GetItemNum { get { return this.circulateList.Count; } }

        public CirculateQueue()
        {
            circulateList = new List<T>();

            circulateID = 0;
        }

        public void SetID_Func(int _id)
        {
            this.circulateID = _id;
        }

        public int GetIndexToItem_Func(T _t)
        {
            return circulateList.IndexOf(_t);
        }

        public T GetItemToIndex_Func(int _idx)
        {
            return circulateList[_idx];
        }

        public void Enqueue_Func(T _t)
        {
            circulateList.AddNewItem_Func(_t);
        }

        public void Enqueue_Func(params T[] _tArr)
        {
            for (int i = 0; i < _tArr.Length; i++)
            {
                circulateList.AddNewItem_Func(_tArr[i]);
            }
        }

        public T Dequeue_Func(bool _isReverse = false)
        {
            if (_isReverse == false)
            {
                circulateID++;

                if (circulateID < circulateList.Count)
                {

                }
                else
                {
                    circulateID = 0;
                }
            }
            else
            {
                circulateID--;

                if (0 <= circulateID)
                {

                }
                else
                {
                    circulateID = circulateList.Count - 1;
                }
            }

            return circulateList[circulateID];
        }
    }

    // Generic Queue가 있어서 사용할 필요 없을 듯...?
    public sealed class Queue_C<T>
    {
        private List<T> queueList;
        public int QueueItemNum { get { return this.queueList.Count; } }
        public bool HasItem { get { return 0 < this.queueList.Count ? true : false; } }

        public Queue_C()
        {
            this.queueList = new List<T>();
        }

        public void Enqueue_Func(T _t)
        {
            this.queueList.AddNewItem_Func(_t);
        }
        public T Dequeue_Func()
        {
            T _returnValue = queueList[0];

            this.queueList.Remove(_returnValue);

            return _returnValue;
        }
        public bool Dequeue_Func(out T _tryGet)
        {
            bool _isHave = false;

            if (0 < queueList.Count)
            {
                _isHave = true;

                _tryGet = this.Dequeue_Func();
            }
            else
            {
                _isHave = false;

                _tryGet = default(T);
            }

            return _isHave;
        }
    }
}
#endregion
#region Curve System
namespace Cargold.CurveSystem
{
    using Cargold.DataStructure;
    using UnityEngine;

    public abstract class CurveSystem_Class : MonoBehaviour
    {
        private Transform curvePivotTrf;                                // 커브 시작지점 트랜스폼
        private Transform curvePointTrf;                                // 커브 지점 트랜스폼

        public virtual float CurveTime_min { get { return 1f; } }       // 커브 시작지점에서부터 도착지점까지 걸리는 최소 시간
        public virtual float CurveTime_max { get { return 2f; } }       // 커브 시작지점에서부터 도착지점까지 걸리는 최소 시간
        public virtual float PushPower_min { get { return 5f; } }       // 커브 시작 시 밀려나는 힘의 최소값
        public virtual float PushPower_max { get { return 10f; } }      // 커브 시작 시 밀려나는 힘의 최대값

        private CirculateQueue<CurveData> circulateQueue;               // 선형큐를 활용한 커브 데이터 풀링

        private int RandNum { get { return 10; } }                      // 커브 데이터 풀링 개수

        public virtual void Init_Func()
        {
            circulateQueue = new CirculateQueue<CurveData>();
            for (int i = 0; i < RandNum; i++)
            {
                CurveData _curveData = this.GetDataByManager_Func();

                circulateQueue.Enqueue_Func(_curveData);
            }

            curvePivotTrf = new GameObject().transform;
            curvePivotTrf.SetParent(this.transform);
            curvePointTrf = new GameObject().transform;
            curvePointTrf.SetParent(curvePivotTrf);
        }
        public void OnCurve_Func(CurvedClass _curvedClass, Vector2 _arrviePos)
        {
            Transform _curvedTrf = _curvedClass.CurvedTrf;

            curvePivotTrf.position = _curvedTrf.position;

            float _curveAngel_Min = _curvedTrf.localEulerAngles.z - _curvedClass.CurveDirectionAngleRange;
            float _curveAngel_Max = _curvedTrf.localEulerAngles.z + _curvedClass.CurveDirectionAngleRange;
            
            CurveData _curveData = _curvedClass.CurveData;
            Vector3 _curvePos = this.GetCurvePos_Func(_curveData.PushPower, _curveAngel_Min, _curveAngel_Max);

            StartCoroutine(Curve_Cor(_curvedTrf, _curvePos, _arrviePos, _curveData.CurveTime, _curvedClass.IsKeepCurving, _curvedClass.IsLookAtOnCurved, _curvedClass.ArriveCurveDel));
        }
        private IEnumerator Curve_Cor(Transform _curvedTrf, Vector2 _curvePos, Vector2 _arrivePos, float _curveTime, bool _isKeepCurving, bool _isLookAtOnCurved, Action _arriveDel)
        {
            if (_curvedTrf == null) yield break;

            Vector2 _startPos = _curvedTrf.position;

            if(_isKeepCurving == false)
            {
                yield return Coroutine_C.GetWaitForSeconds_Cor(_curveTime, delegate (float _progressTime)
                {
                    float _progressRate = _progressTime / _curveTime;

                    Vector2 _movePos = Cargold_Library.GetBezier_Func(_startPos, _curvePos, _arrivePos, _progressRate);

                    if (_isLookAtOnCurved == true)
                        _curvedTrf.LookAt_Func(_movePos);

                    _curvedTrf.transform.position = _movePos;
                });
            }
            else
            {
                float _startTime = Time.time;

                while(true)
                {
                    float _progressRate = (Time.time - _startTime) / _curveTime;

                    Vector2 _movePos = Cargold_Library.GetBezier_Func(_startPos, _curvePos, _arrivePos, _progressRate);

                    if (_isLookAtOnCurved == true)
                        _curvedTrf.LookAt_Func(_movePos);

                    _curvedTrf.transform.position = _movePos;

                    yield return null;
                }
            }

            if (_arriveDel != null)
                _arriveDel();
        }
        private Vector3 GetCurvePos_Func(float _pushPower, float _curveAngle_Min = 0f, float _curveAngle_Max = 360f)
        {
            return Cargold_Library.GetCircumferencePos_Func(curvePointTrf.position, _pushPower, Random.Range(_curveAngle_Min, _curveAngle_Max));
        }
        public CurveData GetCurveData_Func()
        {
            return circulateQueue.Dequeue_Func();
        }

        public CurveData GetDataByManager_Func()
        {
            float _curvingTime = Random.Range(this.CurveTime_min, this.CurveTime_max);
            float _pushPower = Random.Range(this.PushPower_min, this.PushPower_max);

            CurveData _data = new CurveData(_curvingTime, _pushPower);
            
            return _data;
        }
    }
    [System.Serializable]
    public struct CurveData
    {
        [SerializeField] private float curvingTime;     // 시작지점부터 도착지점까지 이동에 걸리는 총 시간
        [SerializeField] private float pushPower;       // 커브 시작 시 밀려나는 힘

        public float CurveTime { get { return curvingTime; } }
        public float PushPower { get { return pushPower; } }

        public CurveData(float _curvingTime, float _pushPower)
        {
            this.curvingTime = _curvingTime;
            this.pushPower = _pushPower;
        }
    }
    [System.Serializable]
    public class CurvedClass
    {
        private Transform curvedTrf;           // 커브할 트랜스폼
        private Action arriveCurveDel;         // 커브의 도착지점에 다다른 후 호출할 함수
        [SerializeField] private bool isLookAtOnCurved = false;           // 커브할 방향을 바라볼 것인가?
        [SerializeField] private bool isKeepCurving = false;              // 커브의 도착 이후에도 계속 커브하며 이동할 것인가?
        [SerializeField] private float curveDirectionAngleRange = 0f;  // 커브 시작각의 범위 (현재 로테이션 z축을 기준으로 랜덤하게 각이 변할 편차값)
        private CurveData curveData;

        public float CurveDirectionAngleRange => this.curveDirectionAngleRange;

        public Transform CurvedTrf { get {  return curvedTrf; } }
        public Action ArriveCurveDel { get { return arriveCurveDel; } }
        public bool IsLookAtOnCurved { get { return isLookAtOnCurved; } }
        public bool IsKeepCurving { get { return isKeepCurving; } }
        public CurveData CurveData { get { return curveData; } }

        public CurvedClass(Transform _curvedTrf, Action _arriveCurveDel, CurveSystem_Class _curveSystemClass)
        {
            this.curvedTrf = _curvedTrf;
            this.arriveCurveDel = _arriveCurveDel;
            
            if(curveDirectionAngleRange == 0f)
                this.curveDirectionAngleRange = 180f;

            this.curveData = _curveSystemClass.GetCurveData_Func();
        }

        public CurvedClass(Transform _curvedTrf, Action _arriveCurveDel, CurveData _curveData)
        {
            this.curvedTrf = _curvedTrf;
            this.arriveCurveDel = _arriveCurveDel;

            if (curveDirectionAngleRange == 0f)
                this.curveDirectionAngleRange = 180f;

            this.curveData = _curveData;
        }
    }
}
#endregion
#region ObjectPool
namespace Cargold.ObjectPool
{
    using Cargold.DataStructure;
    using System.Collections.Generic;
    using System.Text;

    public abstract class PoolingSystem_Manager<PoolingType> : MonoBehaviour
    {
        protected Transform thisTrf;
        protected Dictionary<PoolingType, PoolingSystem> objectPoolDic;

        public virtual void Init_Func()
        {
            objectPoolDic = new Dictionary<PoolingType, PoolingSystem>();

            thisTrf = this.transform;
        }

        public void Generate_ObjectPool_Func(PoolingType _poolingType, GameObject _poolingObj, int _defaultNum, bool _isSetParentTrf = true)
        {
            GameObject _poolingSystemObj = new GameObject("PoolingSystem_" + _poolingType.ToString());
            _poolingSystemObj.transform.SetParent(thisTrf);

            PoolingSystem _poolingSystem = new PoolingSystem();
            _poolingSystem.Init_Func(_poolingSystemObj.transform, _poolingObj, _defaultNum, _isSetParentTrf);

            objectPoolDic.Add_Func(_poolingType, _poolingSystem);
        }
        public void Generate_ComponentPool_Func<ComponentType>(PoolingType _poolingType, GameObject _poolingObj, int _defaultNum, bool _isSetParentTrf = true) where ComponentType : Component, IGeneratedByPoolingSystem
        {
            GameObject _poolingSystemObj = new GameObject("PoolingSystem_" + _poolingType.ToString());
            _poolingSystemObj.transform.SetParent(this.transform);

            PoolingSystem<ComponentType> _poolingSystem = new PoolingSystem<ComponentType>();
            _poolingSystem.Init_Func(_poolingSystemObj.transform, _poolingObj, _defaultNum, _isSetParentTrf);

            objectPoolDic.Add_Func(_poolingType, _poolingSystem);
        }

        public PoolingSystem GetPoolingSystem_Func(PoolingType _poolingType)
        {
            return this.objectPoolDic.GetValue_Func(_poolingType);
        }
        public PoolingSystem<ComponentType> GetPoolingSystem_Func<ComponentType>(PoolingType _poolingType) where ComponentType : Component, IGeneratedByPoolingSystem
        {
            PoolingSystem _poolingSystem = this.objectPoolDic.GetValue_Func(_poolingType);

            return (PoolingSystem<ComponentType>)_poolingSystem;
        }

        public GameObject GetPoolingObj_Func(PoolingType _poolingType)
        {
            return objectPoolDic.GetValue_Func(_poolingType).GetPool_Func();
        }
        public ComponentType GetPoolingComponent_Func<ComponentType>(PoolingType _poolingType) where ComponentType : Component, IGeneratedByPoolingSystem
        {
            PoolingSystem _poolingSystemClass = objectPoolDic.GetValue_Func(_poolingType);

            PoolingSystem<ComponentType> _poolSystem = (PoolingSystem<ComponentType>)_poolingSystemClass;

            return _poolSystem.GetComponent_Func();
        }

        public int GetItemNum_Func(PoolingType _poolingType)
        {
            PoolingSystem _poolingSystemClass = null;

            if (objectPoolDic.TryGetValue(_poolingType, out _poolingSystemClass) == true)
            {
                return _poolingSystemClass.HaveNum;
            }
            else
            {
                Debug.LogWarning(_poolingType + " Key에 해당하는 PoolingSystem이 없습니다.");

                return 0;
            }
        }

        public void Return_Func(PoolingType _poolingType, GameObject _returnObj, bool _isSetParentTrf = true)
        {
            PoolingSystem _poolingSystemClass = objectPoolDic.GetValue_Func(_poolingType);

            _poolingSystemClass.Return_Func(_returnObj, _isSetParentTrf);
        }
        public void Return_Func<ComponentType>(PoolingType _poolingType, ComponentType _returnComponent, bool _isSetParentTrf = true) where ComponentType : Component, IGeneratedByPoolingSystem
        {
            PoolingSystem _poolingSystemClass = objectPoolDic.GetValue_Func(_poolingType);

            PoolingSystem<ComponentType> _poolSystem = (PoolingSystem<ComponentType>)_poolingSystemClass;

            _poolSystem.Return_Func(_returnComponent, _isSetParentTrf);
        }
    }
    public class PoolingSystem
    {
        protected Transform thisTrf;
        protected GameObject poolingObj;
        protected Queue<GameObject> queue;
        protected int poolingCnt;

        public int defaultCount { get; protected set; }
        public virtual bool IsItemHave { get { return this.queue.HasItem_Func(); } }
        public virtual int HaveNum { get { return this.queue.Count; } }

        public virtual void Init_Func(Transform _thisTrf, GameObject _poolObj, int _defaultCount, bool _isSetParentTrf = true)
        {
            this.thisTrf = _thisTrf;
            this.poolingObj = _poolObj;
            this.defaultCount = _defaultCount;
            this.queue = new Queue<GameObject>();
            this.poolingCnt = 0;

            for (int i = 0; i < _defaultCount; i++)
            {
                GameObject _obj = GeneratePoolingObj_Func(_isSetParentTrf);
                _obj.name = this.GetPoolingName_Func();
                this.queue.Enqueue(_obj);
            }
        }
        private GameObject GeneratePoolingObj_Func(bool _isSetParentTrf = true)
        {
            GameObject _obj = GameObject.Instantiate(poolingObj);
            _obj.name = this.GetPoolingName_Func();

            if (_isSetParentTrf == true)
            {
                _obj.transform.SetParent(thisTrf);
            }
            else
            {

            }

            return _obj;
        }

        public virtual GameObject GetPool_Func()
        {
            GameObject _poolingComponent = null;

            if (queue.Dequeue_Func(out _poolingComponent) == true)
            {
                return _poolingComponent;
            }
            else
            {
                return this.GeneratePoolingObj_Func();
            }
        }
        public void Return_Func(GameObject _poolingComponent, bool _isSetParentTrf = true)
        {
            this.queue.Enqueue(_poolingComponent);

            if (_isSetParentTrf == false)
            {

            }
            else
            {
                _poolingComponent.transform.SetParent(thisTrf);
            }
        }

        protected string GetPoolingName_Func()
        {
            this.poolingCnt++;

            return StringBuilder_C.Append_Func(this.poolingObj.name, "_", (this.poolingCnt).ToString());
        }
    }
    public class PoolingSystem<PoolingComponent> : PoolingSystem where PoolingComponent : Component, IGeneratedByPoolingSystem
    {
        private new Queue<PoolingComponent> queue;
        public override bool IsItemHave { get { return this.queue.HasItem_Func(); } }
        public override int HaveNum { get { return this.queue.Count; } } 

        public override void Init_Func(Transform _thisTrf, GameObject _poolObj, int _defaultCount, bool _isSetParentTrf = true)
        {
            this.thisTrf = _thisTrf;
            this.poolingObj = _poolObj;
            this.defaultCount = _defaultCount;
            this.queue = new Queue<PoolingComponent>();

            for (int i = 0; i < _defaultCount; i++)
            {
                PoolingComponent _poolingComponent = GeneratePoolingComponent_Func(_isSetParentTrf);
                _poolingComponent.gameObject.name = base.GetPoolingName_Func();
                this.queue.Enqueue(_poolingComponent);
            }
        }
        private PoolingComponent GeneratePoolingComponent_Func(bool _isSetParentTrf = true)
        {
            GameObject _obj = GameObject.Instantiate(poolingObj);
            _obj.name = base.GetPoolingName_Func();
            if (_isSetParentTrf == true)
                _obj.transform.SetParent(thisTrf);

            PoolingComponent _poolingComponent = _obj.GetComponent<PoolingComponent>();
            if(_poolingComponent != null)
            {
                _poolingComponent.CallI_GenerateByPoolingSystem_Func();
            }
            else
            {
                Debug_C.Error_Func("Null : " + _poolingComponent);
            }

            return _poolingComponent;
        }

        public PoolingComponent GetComponent_Func()
        {
            PoolingComponent _poolingComponent = null;

            if (queue.Dequeue_Func(out _poolingComponent) == true)
            {
                return _poolingComponent;
            }
            else
            {
                return this.GeneratePoolingComponent_Func();
            }
        }
        public override GameObject GetPool_Func()
        {
            PoolingComponent _poolingComponent = this.GetComponent_Func();

            return _poolingComponent.gameObject;
        }
        public void Return_Func(PoolingComponent _poolingComponent, bool _isSetParentTrf = true)
        {
            if(this.queue.Contains(_poolingComponent) == false)
            {
                this.queue.Enqueue(_poolingComponent);

                if (_isSetParentTrf == true)
                    _poolingComponent.transform.SetParent(thisTrf);
            }
            else
            {
                Debug.LogWarning("이미 저장되어 있는 Item을 PoolingSystem에 저장하려고 합니다. : " + _poolingComponent);
            }
        }
    }

    public interface IGeneratedByPoolingSystem
    {
        void CallI_GenerateByPoolingSystem_Func();
    }
}
#endregion
#region Joystick
namespace Cargold.Joystick
{
    using UnityEngine.EventSystems;

    public class JoyStickController_Script : MonoBehaviour
    {
        [SerializeField] private Transform stickTrf = null;
        [SerializeField] private float radius = 0f;           // 조이스틱 배경의 반 지름.
        [SerializeField] private Transform bgTrf = null;
        private Vector2 stickInitPos;  // 조이스틱의 처음 위치.

        public virtual void Init_Func()
        {
            if(radius == 0f)
                radius = this.GetComponent<RectTransform>().sizeDelta.y * 0.5f;

            stickInitPos = stickTrf.transform.position;

            if(bgTrf == null)
                bgTrf = this.transform;

            this.Deactive_Func(true);
        }

        public void Active_Func(Vector2 _touchPos)
        {
            bgTrf.gameObject.SetActive(true);

            bgTrf.position = _touchPos;

            stickInitPos = _touchPos;
            stickTrf.position = _touchPos;

            Coroutine_C.StartCoroutine_Func(StickDragChecker_Cor(), "JoyStick");
        }
        private IEnumerator StickDragChecker_Cor()
        {
            Debug_C.Log_Func("On Cor");

            while(true)
            {
                this.OnDragging_Func(stickTrf.position);

                yield return null;
            }
        }
        protected virtual void OnDragging_Func(Vector2 _stickPos)
        {

        }

        public Vector2 GetJoyDir_Func(Vector2 _dragPos)
        {
            return (_dragPos - stickInitPos).normalized;
        }
        public Vector2 GetJoyDirByDistance_Func(Vector2 _dragPos)
        {
            Vector2 _joyDir = this.GetJoyDir_Func(_dragPos);

            // 조이스틱의 초기 위치와 현재 내 터치 위치와의 거리를 구한다.
            float _dist = Vector3.Distance(_dragPos, stickInitPos);

            // 거리가 반지름보다 작으면 방향과 거리를 곱하고 반환
            if (_dist < radius) return _joyDir * _dist;

            // 거리가 반지름보다 크면 방향에 반지름 크기까지만 곱하고 반환
            else return _joyDir * radius;
        }
        public void SetDragStick_Func(Vector2 _dragPos)
        {
            // 조이스틱 방향 계산
            Vector2 _joyDir = Vector2.zero;

            this.SetDragStick_Func(_dragPos, out _joyDir);
        }
        public void SetDragStick_Func(Vector2 _dragPos, out Vector2 _joyDir)
        {
            // 조이스틱 방향 계산
            _joyDir = this.GetJoyDirByDistance_Func(_dragPos);

            stickTrf.position = _joyDir + stickInitPos;
        }

        public float GetJoyAngle_Func(Vector2 _dragPos)
        {
            //해당 조이스틱의 각도를 계산
            float _angle = Mathf.Atan2(_dragPos.y - stickInitPos.y, _dragPos.x - stickInitPos.x) * 180 / Mathf.PI;

            // 0도가 위를 향하게끔 보정
            _angle -= 90f;

            // 음수가 없게끔 보정
            if (_angle < 0) _angle += 360;

            // 시계방향으로 각이 형성되게끔 보정
            _angle = 360f - _angle;
            return _angle;
        }

        // 드래그 끝.
        public void Deactive_Func(bool _isInit = false)
        {
            if(_isInit == false)
                Coroutine_C.StopCoroutine_Func("JoyStick");

            stickTrf.position = stickInitPos; // 스틱을 원래의 위치로.

            bgTrf.gameObject.SetActive(false);
        }
    }
}
#endregion
#region Reserve
namespace Cargold.ReserveSystem
{
    [System.Serializable]
    public class ReserveSystem
    {
        private float timer;
        private bool isReserve;
        private bool isImmediate;
        private float nextChangeTime;
        private Action callback;
        private Coroutine cor;
        private MonoBehaviour coroutineCallerObj;

        public ReserveSystem(float _nextChangeTime, Action _callback, MonoBehaviour _coroutineCallerObj)
        {
            this.nextChangeTime = _nextChangeTime;
            this.callback = _callback;
            coroutineCallerObj = _coroutineCallerObj;
        }

        public void Activate_Func()
        {
            timer = Time.time;
            isReserve = false;
            isImmediate = false;

            cor = coroutineCallerObj.StartCoroutine(this.Reserve_Cor());
        }
        public void OnReserve_Func(bool _isImmediate = false)
        {
            if (isReserve == false)
                isReserve = true;

            this.isImmediate = _isImmediate;
        }
        public IEnumerator Reserve_Cor()
        {
            while (true)
            {
                bool _isTimeOver = false;

                if (isImmediate == false)
                {
                    if (isReserve == true)
                    {
                        if (Time.time < timer)
                        {

                        }
                        else
                        {
                            _isTimeOver = true;
                        }
                    }
                }
                else
                {
                    _isTimeOver = true;
                }

                if (_isTimeOver == false)
                {

                }
                else
                {
                    timer = Time.time + this.nextChangeTime;
                    isReserve = false;
                    isImmediate = false;

                    this.callback();
                }

                yield return null;
            }
        }
        public void Deactivate_Func()
        {
            coroutineCallerObj.StopCoroutine(this.cor);
            this.cor = null;
        }
    }
}
#endregion

// Static Class
#region Debug_C
public static class Debug_C
{
    [System.Diagnostics.Conditional("Test_Cargold")]
    public static void Log_Func(object _object)
    {
        UnityEngine.Debug.Log("Test_Cargold : " + _object);
    }

    [System.Diagnostics.Conditional("Test_Cargold")]
    public static void Warning_Func(object _object)
    {
        UnityEngine.Debug.LogWarning("Test_Cargold : " + _object);
    }

    [System.Diagnostics.Conditional("Test_Cargold")]
    public static void Error_Func(object _object)
    {
        UnityEngine.Debug.LogError("Test_Cargold : " + _object);
    }

    [System.Diagnostics.Conditional("Test_Cargold")]
    public static void Log_Func(string _string)
    {
        UnityEngine.Debug.Log("Test_Cargold : " + _string);
    }

    [System.Diagnostics.Conditional("Test_Cargold")]
    public static void Warning_Func(string _string)
    {
        UnityEngine.Debug.LogWarning("Test_Cargold : " + _string);
    }

    [System.Diagnostics.Conditional("Test_Cargold")]
    public static void Error_Func(string _string)
    {
        UnityEngine.Debug.LogError("Test_Cargold : " + _string);
    }

}
#endregion
#region StringBuilder_C
public static class StringBuilder_C
{
    private static StringBuilder staticBuilder;
    public static StringBuilder AccessCarefully
    {
        get
        {
            if (staticBuilder == null)
                staticBuilder = new StringBuilder(1024);

            return staticBuilder;
        }
    }

    // 최적화 이슈 확인 필요함
    public static string Append_Func(params int[] _valueArr)
    {
        string[] _castingArr = new string[_valueArr.Length];
        for (int i = 0; i < _valueArr.Length; i++)
        {
            _castingArr[i] = _valueArr[i].ToString();
        }

        return Append_Func(_castingArr);
    }
    // 최적화 이슈 확인 필요함
    public static string Append_Func(params float[] _valueArr)
    {
        string[] _castingArr = new string[_valueArr.Length];
        for (int i = 0; i < _valueArr.Length; i++)
        {
            _castingArr[i] = _valueArr[i].ToString();
        }

        return Append_Func(_castingArr);
    }
    public static string Append_Func(params string[] _valueArr)
    {
        if (staticBuilder == null)
            staticBuilder = new StringBuilder(1024);

        staticBuilder.RemoveAll_Func();

        for (int i = 0; i < _valueArr.Length; i++)
        {
            staticBuilder.Append(_valueArr[i]);
        }

        return staticBuilder.ToString();
    }
}
#endregion
#region Coroutine_C
public static class Coroutine_C
{
    private class CoroutineClass_C : Cargold.Singleton.Singleton_Func<CoroutineClass_C>
    {
        private bool isInitialize = false;
        private Dictionary<string, Coroutine> coroutineDic;

        public bool IsInitialize { get { return isInitialize; } }

        public override void Init_Func()
        {
            if(isInitialize == false)
            {
                isInitialize = true;

                coroutineDic = new Dictionary<string, Coroutine>();
            }
        }

        public Coroutine StartCoroutine_Func(IEnumerator _enumerator, string _key = "")
        {
            Coroutine _cor = this.StartCoroutine_Func(_enumerator);
            this.coroutineDic.Add_Func(_key, _cor);

            return _cor;
        }
        public Coroutine StartCoroutine_Func(IEnumerator _enumerator)
        {
            return this.StartCoroutine(_enumerator);
        }
        public void StopCoroutine_Func(string _key)
        {
            Coroutine _cor = null;
            if(this.coroutineDic.TryRemove_Func(_key, out _cor) == true)
                StopCoroutine(_cor);
        }
    }
    
    private static WaitForFixedUpdate waitForFixedUpdate;
    public static WaitForFixedUpdate WaitForFixedUpdate
    {
        get
        {
            if (waitForFixedUpdate == null) waitForFixedUpdate = new WaitForFixedUpdate();

            return waitForFixedUpdate;
        }
    }
    
    public static IEnumerator GetWaitForSeconds_Cor(float _time = 0.02f, Action<float> _progressTimeDel = null)
    {
        float _loopBeginTime = Time.time;

        while (Time.time < _loopBeginTime + _time)
        {
            if (_progressTimeDel != null)
                _progressTimeDel(Time.time - _loopBeginTime);

            yield return null;
        }
    }

    public static Coroutine StartCoroutine_Func(IEnumerator _enumerator, string _key = "")
    {
        if (CoroutineClass_C.Instance.IsInitialize == false)
            CoroutineClass_C.Instance.Init_Func();

        return CoroutineClass_C.Instance.StartCoroutine_Func(_enumerator, _key);
    }
    public static Coroutine StartCoroutine_Func(IEnumerator _enumerator)
    {
        return CoroutineClass_C.Instance.StartCoroutine_Func(_enumerator);
    }
    public static void StopCoroutine_Func(Coroutine _cor)
    {
        CoroutineClass_C.Instance.StopCoroutine(_cor);
    }

    public static void StopCoroutine_Func(string _key)
    {
        if (CoroutineClass_C.Instance.IsInitialize == false)
            CoroutineClass_C.Instance.Init_Func();

        CoroutineClass_C.Instance.StopCoroutine_Func(_key);
    }

    public static Coroutine Invoke_Func(Action _del, float _time)
    {
        if (CoroutineClass_C.Instance.IsInitialize == false)
            CoroutineClass_C.Instance.Init_Func();

        return CoroutineClass_C.Instance.StartCoroutine(Coroutine_C.Invoke_Cor(_del, _time));
    }
    private static IEnumerator Invoke_Cor(Action _del, float _time)
    {
        yield return Coroutine_C.GetWaitForSeconds_Cor(_time);

        _del();
    }
}
#endregion
#region Random_C
public static class Random_C
{
    public static int Random_Func(int _min, int _max)
    {
        return UnityEngine.Random.Range(_min, _max);
    }
    public static float Random_Func(float _min, float _max)
    {
        return UnityEngine.Random.Range(_min, _max);
    }
    public static bool CheckPercent_Func(int _maxPercent, int _checkPercent = 0)
    {
        return UnityEngine.Random.Range(0, _maxPercent) == _checkPercent;
    }
}
#endregion

// Developing System
#region TextPrint_Manager
namespace Cargold.TextPrint
{
    //public class TextPrint_Manager : MonoBehaviour
    //{
    //    public static TextPrint_Manager Instance;

    //    [SerializeField] private Color printColor;
    //    [SerializeField] private float punchTime;
    //    [SerializeField] private float printSize;
    //    [SerializeField] private float printTime;
    //    [SerializeField] private float clearTime;
    //    public Color PrintColor { get { return printColor; } }
    //    public float PunchTime { get { return punchTime; } }
    //    public float PrintSize { get { return printSize; } }
    //    public float PrintTime { get { return printTime; } }
    //    public float ClearTime { get { return clearTime; } }
    //    public static Color _a;

    //    [SerializeField] private Transform dpGroupTrf;
    //    private List<TextPrint_Script> dpList;
    //    [SerializeField] private GameObject dpObj;

    //    public void Init_Func()
    //    {
    //        Instance = this;

    //        dpList = new List<TextPrint_Script>();
    //        for (int i = 0; i < 10; i++)
    //        {
    //            GenerateDP_Func();
    //        }
    //    }
    //    private TextPrint_Script GenerateDP_Func()
    //    {
    //        GameObject _dpObj = Instantiate(dpObj);
    //        _dpObj.transform.SetParent(dpGroupTrf);

    //        TextPrint_Script _dpClass = _dpObj.GetComponent<TextPrint_Script>();
    //        _dpClass.Init_Func();
    //        dpList.Add(_dpClass);
    //        _dpObj.SetActive(false);

    //        return _dpClass;
    //    }

    //    public void Print_Func(Vector2 _pos, string _value, Sprite _sprite = null)
    //    {
    //        Print_Func(_pos, _value, PrintColor, _sprite);
    //    }
    //    public void Print_Func(Vector2 _pos, float _value)
    //    {
    //        Print_Func(_pos, _value, PrintColor);
    //    }
    //    public void Print_Func(Vector2 _pos, float _value, Color _color)
    //    {
    //        Print_Func(_pos, ((int)_value).ToString(), _color);
    //    }
    //    public void Print_Func(Vector2 _pos, string _value, Color _color, Sprite _sprite = null, params float[] _varArr)
    //    {
    //        TextPrint_Script _textPrintClass = null;
    //        if (0 < dpList.Count)
    //        {
    //            _textPrintClass = this.dpList[0];
    //            this.dpList.RemoveAt(0);
    //        }
    //        else
    //        {
    //            _textPrintClass = GenerateDP_Func();
    //        }

    //        _textPrintClass.Print_Func(_pos, _value, _color, null, _varArr);
    //    }

    //    public void PrintOver_Func(TextPrint_Script _textPrintClass)
    //    {
    //        this.dpList.Add(_textPrintClass);
    //    }
    //}
    //public class TextPrint_Script : MonoBehaviour
    //{
    //    public Text damageText;
    //    private float punchTime;
    //    private float printSize;
    //    private float printTime;
    //    private float clearTime;
    //    [SerializeField]
    //    private Image printImage;

    //    public void Init_Func()
    //    {
    //        this.gameObject.SetActive(false);
    //    }
    //    public void Print_Func(Vector2 _pos, string _value, Color _color, Sprite _sprite = null, params float[] _varArr)
    //    {
    //        if (_sprite != null)
    //        {
    //            printImage.SetFade_Func(1f);
    //            printImage.SetNativeSize_Func(_sprite);
    //        }

    //        if (_varArr.Length != 4)
    //        {
    //            punchTime = TextPrint_Manager.Instance.PunchTime;
    //            printSize = TextPrint_Manager.Instance.PrintSize;
    //            printTime = TextPrint_Manager.Instance.PrintTime;
    //            clearTime = TextPrint_Manager.Instance.ClearTime;
    //        }
    //        else
    //        {
    //            punchTime = 0f < _varArr[0] ? _varArr[0] : TextPrint_Manager.Instance.PunchTime;
    //            printSize = 0f < _varArr[1] ? _varArr[1] : TextPrint_Manager.Instance.PrintSize;
    //            printTime = 0f < _varArr[2] ? _varArr[2] : TextPrint_Manager.Instance.PrintTime;
    //            clearTime = 0f < _varArr[3] ? _varArr[3] : TextPrint_Manager.Instance.ClearTime;
    //        }

    //        this.gameObject.SetActive(true);

    //        damageText.text = _value;
    //        damageText.color = _color;

    //        this.transform.position = _pos;
    //        this.transform.localScale = Vector3.zero;
    //        this.transform.DOScale(Vector3.one * printSize, punchTime);

    //        damageText.DOColor(_color, printTime).OnComplete(DoClear_Func);
    //    }

    //    public void DoClear_Func()
    //    {
    //        damageText.DOColor(Color.clear, clearTime);

    //        this.transform.DOScale(Vector3.zero, clearTime).OnComplete(PrintOver_Func);
    //    }

    //    public void PrintOver_Func()
    //    {
    //        if (printImage.sprite != null)
    //        {
    //            printImage.sprite = null;
    //            printImage.SetFade_Func(0f);
    //        }

    //        this.gameObject.SetActive(false);

    //        TextPrint_Manager.Instance.PrintOver_Func(this);
    //    }
    //}
}
#endregion
#region Tween
//namespace Cargold.Tween
//{
//    using DG.Tweening;

//    [System.Serializable]
//    public class TweenRepeat
//    {
//        [SerializeField] private Transform[] targetRTrfArr;
//        [SerializeField] private Tweener[] targetTwnArr;
//        [SerializeField] private Vector3 originScale;

//        public static TweenRepeat Init_Func(Vector3 _punch, float _duration, params Transform[] _targetRTrfArr)
//        {
//            return TweenRepeat.Init_Done_Func(_punch, _duration, Vector3.one, _targetRTrfArr : _targetRTrfArr);
//        }
//        public static TweenRepeat Init_Func(Vector3 _punch, float _duration, int _vibrato = 10, float _elasticity = 1, params Transform[] _targetRTrfArr)
//        {
//            return TweenRepeat.Init_Done_Func(_punch, _duration, Vector3.one, _vibrato, _elasticity, _targetRTrfArr);
//        }
//        public static TweenRepeat Init_Func(Vector3 _punch, float _duration, Vector3 _originScale, int _vibrato = 10, float _elasticity = 1, params Transform[] _targetRTrfArr)
//        {
//            return TweenRepeat.Init_Done_Func(_punch, _duration, _originScale, _vibrato, _elasticity, _targetRTrfArr);
//        }
//        private static TweenRepeat Init_Done_Func(Vector3 _punch, float _duration, Vector3 _originScale, int _vibrato = 10, float _elasticity = 1, params Transform[] _targetRTrfArr)
//        {
//            TweenRepeat _initTweenRepeat = new TweenRepeat();

//            _initTweenRepeat.targetRTrfArr = new Transform[_targetRTrfArr.Length];
//            _initTweenRepeat.targetTwnArr = new Tweener[_targetRTrfArr.Length];
//            _initTweenRepeat.originScale = _originScale;

//            for (int i = 0; i < _targetRTrfArr.Length; i++)
//            {
//                Transform _targetTrf = _targetRTrfArr[i];
//                _initTweenRepeat.targetRTrfArr[i] = _targetTrf;

//                _initTweenRepeat.targetTwnArr[i] = _targetTrf.DOPunchScale(_punch, _duration, _vibrato, _elasticity).OnComplete(delegate ()
//                {
//                    _targetTrf.localScale = _originScale;
//                }).SetAutoKill(false);

//                _initTweenRepeat.targetTwnArr[i].Pause();
//            }

//            return _initTweenRepeat;
//        }

//        public void DOPunchScale_Func()
//        {
//            for (int i = 0; i < this.targetTwnArr.Length; i++)
//            {
//                if (targetTwnArr[i].IsActive() == true)
//                    targetTwnArr[i].Pause();

//                targetRTrfArr[i].localScale = originScale;

//                targetTwnArr[i].Restart();
//            }
//        }
//    }
//}
#endregion
#region Gacha
namespace Cargold.Gacha
{
    [System.Serializable]
    public class GachaData
    {
        public int floatingPropability;
    }

    [System.Serializable]
    public class GachaData_ID : GachaData
    {
        public string gachaID;
    }

    [System.Serializable]
    public class GachaSystem
    {
        [SerializeField] private GachaData_Sibling[] siblingArr;
        [SerializeField] private GachaData_Node rootNode;
        [SerializeField] private GachaData_Node[] leafNodeArr;
        [SerializeField] private int totalFPvalue;

        public GachaSystem(GachaData_ID[] _gachaDataArr, int _splitScale = 2, bool _isTest = true)
        {
            int _maxNodeLevel = 0;
            for (int _i = _gachaDataArr.Length; _splitScale <= _i; _maxNodeLevel++)
            {
                _i /= _splitScale;
            }

            siblingArr = new GachaData_Sibling[_maxNodeLevel];
            int _childNum = _gachaDataArr.Length;
            int _nodeNum = 1;

            for (int _nodeLevel = 0; _nodeLevel < _maxNodeLevel; _nodeLevel++)
            {
                int _gachaIdPivot = 0;

                GachaData_Sibling _sibling = new GachaData_Sibling();
                _sibling.siblingLevel = _nodeLevel;

                _nodeNum *= _splitScale;
                GachaData_Node[] _nodeArr = new GachaData_Node[_nodeNum];

                _childNum /= _splitScale;

                NodeType _nodeType = NodeType.None;
                if (0 < _nodeLevel)
                {
                    if (_nodeLevel < _maxNodeLevel)
                        _nodeType = NodeType.Noraml;
                    else
                        _nodeType = NodeType.Leaf;
                }
                else
                    _nodeType = NodeType.Root;

                for (int _nodeID = 0; ; _nodeID++)
                {
                    int _gachaCheckedCnt = 0;
                    _nodeArr[_nodeID] = new GachaData_Node();
                    _nodeArr[_nodeID].nodeType = _nodeType;

                    if (_nodeID < _nodeArr.Length - 1)
                    {
                        _nodeArr[_nodeID].childDataArr = new GachaData[_childNum];

                        for (int _gachaID = 0; _gachaID < _childNum; _gachaID++)
                        {
                            _nodeArr[_nodeID].childDataArr[_gachaID] = _gachaDataArr[_gachaIdPivot];
                            _nodeArr[_nodeID].floatingPropability += _gachaDataArr[_gachaIdPivot].floatingPropability;

                            _gachaIdPivot++;
                            _gachaCheckedCnt++;
                        }
                    }
                    else
                    {
                        int _remainNodeNum = _childNum - _gachaCheckedCnt;
                        _nodeArr[_nodeID].childDataArr = new GachaData[_remainNodeNum];

                        for (int _gachaID = 0; _gachaID < _remainNodeNum; _gachaID++)
                        {
                            _nodeArr[_nodeID].childDataArr[_gachaID] = _gachaDataArr[_gachaIdPivot];
                            _nodeArr[_nodeID].floatingPropability += _gachaDataArr[_gachaIdPivot].floatingPropability;

                            _gachaIdPivot++;
                            _gachaCheckedCnt++;
                        }

                        break;
                    }
                }

                _sibling.nodeArr = _nodeArr;

                this.siblingArr[_nodeLevel] = _sibling;
            }
        }


        public GachaSystem(GachaData_ID[] _gachaDataArr, int _splitScale = 2)
        {
            // 가챠 시스템의 
            int _dataNum = _gachaDataArr.Length;
            int _maxNodeLevel = 0;
            for (int _i = _splitScale; _i < _dataNum; _maxNodeLevel++)
            {
                _i *= _splitScale;
            }

            siblingArr = new GachaData_Sibling[_maxNodeLevel];

            Debug_C.Log_Func("_maxNodeLevel : " + _maxNodeLevel);
            Debug_C.Log_Func("Length : " + this.siblingArr.Length);

            for (int i = 0; i < _maxNodeLevel; i++)
            {
                GachaData_Sibling _sibling = new GachaData_Sibling();
                _sibling.siblingLevel = i;
                GachaData[] _nodeArr = null;

                if (0 < i)
                {
                    _nodeArr = this.siblingArr[i - 1].nodeArr;

                    if (i < _maxNodeLevel)
                    {
                        SetSibling_Func(_sibling, _nodeArr, NodeType.Noraml, _splitScale);
                    }
                    else
                    {
                        SetSibling_Func(_sibling, _nodeArr, NodeType.Root, _splitScale);

                        this.rootNode = _sibling.nodeArr[0];
                    }
                }
                else
                {
                    _nodeArr = _gachaDataArr;
                    SetSibling_Func(_sibling, _nodeArr, NodeType.Leaf, _splitScale);
                }

                Debug_C.Log_Func("i : " + i);
                this.siblingArr[i] = _sibling;
            }

            /*

            List<GachaData> _gachaDataList = new List<GachaData>();
            List<GachaData> _gachaDataList_Next = new List<GachaData>();
            _gachaDataList_Next.AddNewItem_Func(_gachaDataArr);

            int _gachaDataID = 0;
            int _nodeLevel = 0;
            int _totalPF = 0;

            while (_splitScale < _gachaDataList_Next.Count)
            {
                _gachaDataList.AddRange(_gachaDataList_Next);
                _gachaDataList_Next.Clear();

                GachaData_Sibling _sibling = new GachaData_Sibling();
                _sibling.siblingLevel = _nodeLevel;
                _sibling.nodeList = new List<GachaData_Node>();

                if (0 < _nodeLevel)
                {
                    NodeType _nodeType = NodeType.Noraml;

                    GachaData_Node _node = new GachaData_Node();
                    _node.nodeType = _nodeType;
                    _node.childDataArr = new GachaData[_splitScale];

                    List<GachaData_Node> _nodeList = this.siblingList[_nodeLevel - 1].nodeList;

                    for (int i = 0; i < _splitScale; i++)
                    {

                        _node.childDataArr[i] = null;
                        _gachaDataID++;
                    }

                    _sibling.nodeList.AddNewItem_Func(_node);
                }
                else
                {
                    for (int i = 0; i < _gachaDataArr.Length; i++)
                    {
                        NodeType _nodeType = NodeType.Leaf;

                        GachaData_Node _node = new GachaData_Node();
                        _node.nodeType = _nodeType;
                        _node.childDataArr = new GachaData[_splitScale];

                        for (int j = 0; j < _splitScale; j++, i++)
                        {
                            GachaData_ID<GachaID> _gachaData = _gachaDataArr[_gachaDataID];
                            _totalPF += _gachaData.floatingPropability;

                            _node.childDataArr[j] = _gachaData;
                            _gachaDataID++;
                        }

                        _sibling.nodeList.AddNewItem_Func(_node);
                    }
                }

                _nodeLevel++;
                this.siblingList.AddNewItem_Func(_sibling);
            }









            






            // 가챠 시스템의 
            int _dataNum = _gachaDataArr.Length;
            int _groupDepth = 0;
            for (int _i = _splitScale; _i < _dataNum; _groupDepth++)
            {
                _i *= _splitScale;
            }
            
            // 전체 유동확률값 계산
            for (int i = 0; i < _gachaDataArr.Length; i++)
                this.totalFPvalue += _gachaDataArr[i].floatingPropability;
            
            this.siblingArr = new GachaData_Sibling[_groupDepth];
            this.siblingArr[0] = new GachaData_Sibling();
            this.siblingArr[0].siblingLevel = 0;
            this.siblingArr[0].nodeArr = new GachaData_Node[1];
            this.siblingArr[0].nodeArr[0] = GachaData_Node.Init_RoofNode_Func(null);

            for (int i = 0; i < _dataNum; i++)
            {
                GachaData_Node _chain = new GachaData_Node();
                _chain.childDataArr = null;
                _chain.parentData = _gachaDataArr[i];

                this.siblingArr[0].nodeArr[i] = _chain;
            }

            for (int i = 1; i < _groupDepth; i++)
            {
                GachaData_Node[] _chainDataArr = this.siblingArr[i-1].nodeArr;

                int _splitedChainNum = _chainDataArr.Length / _splitScale;

                GachaData_Sibling _groupClass = new GachaData_Sibling();
                _groupClass.siblingLevel = i;

                for (int j = 0, _dataID = 0; j < _splitScale; j++)
                {
                    GachaData_Node _chain = new GachaData_Node();
                    _chain.childDataArr = new GachaData[_splitedChainNum];

                    _groupClass.dataArr[j] = _chain;
                    
                    for (int k = 0; k < _splitedChainNum; k++)
                    {
                        _chain.childDataArr[_dataID] = _chainDataArr[_dataID];
                    }
                }

                

                this.siblingArr[i] = _groupClass;
            }

            for (int i = 0; i < _gachaDataArr.Length; i++)
            {
                totalFPvalue += _gachaDataArr[i].floatingPropability;
            }

            */
        }

        private void SetSibling_Func(GachaData_Sibling _sibling, GachaData[] _nodeArr, NodeType _nodeType, int _splitScale)
        {
            _sibling.nodeArr = new GachaData_Node[_nodeArr.Length / 2];
            int _nodeIdPivot = 0;

            for (int j = 0; ; j++)
            {
                GachaData_Node _node = new GachaData_Node();
                _node.nodeType = _nodeType;

                if (j < _sibling.nodeArr.Length)
                {
                    _node.childDataArr = new GachaData[_splitScale];

                    for (int k = 0; k < _splitScale; k++)
                    {
                        GachaData _gachaData = _nodeArr[_nodeIdPivot];
                        _node.childDataArr[k] = _gachaData;
                        _node.floatingPropability += _gachaData.floatingPropability;

                        _nodeIdPivot++;
                    }
                }
                else
                {
                    int _remainNodeNum = _nodeArr.Length - _nodeIdPivot;
                    _node.childDataArr = new GachaData[_remainNodeNum];

                    for (int k = 0; k < _remainNodeNum; k++)
                    {
                        GachaData _gachaData = _nodeArr[_nodeIdPivot];
                        _node.childDataArr[k] = _gachaData;
                        _node.floatingPropability += _gachaData.floatingPropability;

                        _nodeIdPivot++;
                    }

                    break;
                }

                _sibling.nodeArr[j] = _node;
            }
        }

        //public GachaID GetGachaID_Func()
        //{
        //    int _randValue = UnityEngine.Random.Range(0, this.totalFPvalue);

        //    return this.gachaDataArr[0].gachaID;
        //}

        [System.Serializable]
        private class GachaData_Node : GachaData
        {
            public NodeType nodeType;
            public GachaData[] childDataArr;

            //private GachaData_Node(NodeType _nodeType, GachaData_Node _parentNode, GachaData_Node[] _childNodeArr)
            //{
            //    this.nodeType = _nodeType;
            //    this.parentData = _parentNode;
            //    this.childDataArr = _childNodeArr;
            //}

            //public static GachaData_Node Init_RoofNode_Func(GachaData_Node[] _childNodeArr)
            //{
            //    GachaData_Node _node = new GachaData_Node
            //    (
            //        NodeType.Root,
            //        null,
            //        _childNodeArr
            //    );

            //    return _node;
            //}
            //public static GachaData_Node Init_NoramlNode_Func(GachaData_Node _parentNode, GachaData_Node[] _childNodeArr)
            //{
            //    GachaData_Node _node = new GachaData_Node
            //    (
            //        NodeType.Noraml,
            //        _parentNode,
            //        _childNodeArr
            //    );

            //    return _node;
            //}
            //public static GachaData_Node Init_LeafNode_Func(GachaData_Node _parentNode)
            //{
            //    GachaData_Node _node = new GachaData_Node
            //    (
            //        NodeType.Leaf,
            //        _parentNode,
            //        null
            //    );

            //    return _node;
            //}

            //public NodeType NodeType { get => nodeType; set => nodeType = value; }
        }

        [System.Serializable]
        private class GachaData_Sibling
        {
            public int siblingLevel;
            public GachaData_Node[] nodeArr;
        }
    }

    public enum NodeType
    {
        None = -1,

        Root,
        Noraml,
        Leaf,
    }
}
#endregion
#region Abstract Data
// 용도 : 부모 인터페이스에서 어느 타입인지 확인하고서 적합한 타입으로 다운 캐스팅한 후 데이터 Get하기
// 개선 : 밸류들을 데이터용 클래스에 기록한 뒤 인자로 주고 받으면 어떨까? 매니저가 데이터 클래스를 풀링한 뒤 관리
namespace Cargold.AbstractData
{
    public interface IAbstractData
    {
        AbstractDataType GetAbstractDataType_Func();
    }

    public interface IAD_Int : IAbstractData
    {
        int GetAD_Int_Func();
    }

    public interface IAD_Int_2 : IAbstractData
    {
        AD_Int_2 GetAD_Int_2_Func();
    }

    public interface IAD_Float_2 : IAbstractData
    {
        AD_Float_2 GetAD_Float_2_Func();
    }

    public interface IAD_Int_Float : IAbstractData
    {
        AD_Int_Float GetAD_Int_Float_Func();
    }

    public struct AD_Int_2 { public int value1, value2; }
    public struct AD_Int_Float { public int intValue; public float floatValue; }
    public struct AD_Float_2 { public float value1, value2; }

    public enum AbstractDataType
    {
        None = 0,

        Int,
        Int_2,

        Int_Float,

        Float2,

        Vector2,

        Vector3,
    }
}
#endregion

// Coming Soon...
#region Dragger
// Potion 게임에서 쓰던 SelectMatter를 범용적으로 모듈화하여 WhichOne처럼 쓸모있게 만들자
// 1. 끌고 다니는게, 선택한 객체 그 자체일 수도 있고, 새로운 드래깅 객체일 수도 있고 ㅇㅇ
// 2. 드래그의 동기화 속도를 조절 가능하게끔
#endregion
#region TagDictionary
/*
 * 개체 하나에 태그를 여러개 지정할 경우
 * 딕셔너리에 태그를 Key로 써서 개체를 찾는 기능
 * 고로 한 개체가 여러개의 딕셔너리에 등록됨
 * 
 * 개체에 한 태그만 제거할 경우엔 관련 딕셔너리에서 Remove하면 된다.
 * 하지만 개체가 제거될 경우 개체의 태그와 관련된 모든 딕셔너리에 접근해서 제거해야 한다.
 */
#endregion
#region Sound System
#endregion
#region Trash Group
namespace Cargold.Trash
{
    public class RaritySort
    {
        // 임의로 명명한 등급 순으로 영웅을 정렬하고 싶을 때 어떻게 하는가?

        public string[] fixRarityArr = { "SSS", "SS", "S", "AAA", "A", "B", "C", "D" };
        public List<hero_dic_info> hero_Dic_Info_Item;

        public class hero_dic_info
        {
            public string rarity;

            public hero_dic_info(string _rarity)
            {
                this.rarity = _rarity;
            }
        }

        private void Start()
        {
            hero_Dic_Info_Item = new List<hero_dic_info>();

            this.ReadCsv_Func(this.hero_Dic_Info_Item);

            this.Sort_Func(this.hero_Dic_Info_Item);

            this.PrintDesc_Func(this.hero_Dic_Info_Item);
        }

        private void ReadCsv_Func(List<hero_dic_info> _setList)
        {
            for (int i = 0; i < 10; i++)
            {
                int _randRarityID = UnityEngine.Random.Range(0, fixRarityArr.Length);
                string _randRarity = fixRarityArr[_randRarityID];
                hero_dic_info _info = new hero_dic_info(_randRarity);
                _setList.Add(_info);
            }
        }

        private void Sort_Func(List<hero_dic_info> _sortList)
        {
            for (int x = 0; x < _sortList.Count - 1; x++)
            {
                for (int y = x + 1; y < _sortList.Count; y++)
                {
                    hero_dic_info _x = _sortList[x];
                    hero_dic_info _y = _sortList[y];

                    int _xRarityID = this.GetRarityID_Func(_x);
                    int _yRarityID = this.GetRarityID_Func(_y);

                    if (_yRarityID < _xRarityID)
                    {
                        this.SwapHero_Func(ref _x, ref _y);

                        _sortList[x] = _x;
                        _sortList[y] = _y;

                        continue;
                    }
                    else
                    {

                    }
                }
            }
        }

        private int GetRarityID_Func(hero_dic_info _heroInfoClass)
        {
            for (int _rarity = 0; _rarity < this.fixRarityArr.Length; _rarity++)
            {
                if (_heroInfoClass.rarity != this.fixRarityArr[_rarity])
                {

                }
                else
                {
                    return _rarity;
                }
            }

            throw new Exception("해당 등급이 없다능");
        }

        private void SwapHero_Func(ref hero_dic_info _x, ref hero_dic_info _y)
        {
            hero_dic_info _temp = _x;

            _x = _y;

            _y = _temp;
        }

        private void PrintDesc_Func(List<hero_dic_info> _printList)
        {
            for (int i = 0; i < _printList.Count; i++)
            {
                Debug.Log(i + " / " + _printList[i].rarity);
            }
        }
    }
}
#endregion
#region Wrapping
namespace Cargold.Wrapping
{
    // GC 없이 Enum을 Int로 캐스팅하는 내용인데, 다른 용도로도 쓸 수 있을 듯?

    class WrapperObject<TEnum, TValue>
    {
        TValue[] data;

        static Dictionary<TEnum, int> _enumKey = new Dictionary<TEnum, int>();

        static WrapperObject()
        {
            int[] intValues = Enum.GetValues(typeof(TEnum)) as int[];
            TEnum[] enumValues = Enum.GetValues(typeof(TEnum)) as TEnum[];

            for (int i = 0; i < intValues.Length; i++)
            {
                _enumKey.Add(enumValues[i], intValues[i]);
            }
        }

        public WrapperObject(int count)
        {
            data = new TValue[count];
        }

        public TValue this[TEnum key]
        {
            get { return data[_enumKey[key]]; }
            set { data[_enumKey[key]] = value; }
        }
    }
}
#endregion
#region Sort
namespace Cargold.Sort
{
    // 정렬 알고리즘 ㄱㄱ
}
#endregion