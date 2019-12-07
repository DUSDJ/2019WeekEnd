using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Resume
{
    public List<Incident> IncidentList;
    public List<Quirk> QuirkList;
    public List<Favor> FavorList;


    public Resume()
    {
        List<Incident> IncidentList = new List<Incident>();
        List<Quirk> QuirkList = new List<Quirk>();
        List<Favor> FavorList = new List<Favor>();
        }
}


public class Incident
{

}

public class Quirk
{
    public void Action()
    {

    }
}

public class Favor
{

}