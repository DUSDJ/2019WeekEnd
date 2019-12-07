using System.Collections;

public interface INeedInitialize
{
    IEnumerator InitializeCoroutine();
}

public interface INeedInitializeSameTime
{
    void Initialize();
}