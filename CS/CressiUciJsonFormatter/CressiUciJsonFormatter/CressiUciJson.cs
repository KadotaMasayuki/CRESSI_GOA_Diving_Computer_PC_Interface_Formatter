using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 2022/2/16
//  つくりかけ。Nullのエントリがあって、大混乱。
//  シリアライズしないで、ノードでアクセスすることにする。
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!
//  !!!!!!!!!! このクラスは使わない !!!!!!!!!!


namespace CressiUciJsonFormatter
{
    class CressiUciJson
    {
        List<ConfigCressiUCI> configCressiUci = new List<ConfigCressiUCI>();
    }

    class ConfigCressiUCI
    {
        int ID { get; set; }
        int ID_Lingua { get; set; }
        int UM { get; set; }
    }

    class Subacquei
    {
        int ID { get; set; }
        string nome { get; set; }
        string cognome { get; set; }
        string Dan_ID { get; set; }
        string Dan_Password { get; set; }
    }

    class Device
    {
        int ID { get; set; }
        string model_type { get; set; }
        string fw_version { get; set; }
        string serial_number { get; set; }
        string name { get; set; }
        string ultima_sicronizzazione { get; set; }
        string NomeSub { get; set; }
        string Dan_ID { get; set; }
        string Dan_Password { get; set; }
    }
    class Localita
    {
        int ID { get; set; }
        int ID_Nazione { get; set; }
        string nome_localita { get; set; }
    }
    class Siti
    {
        int ID { get; set; }
        int ID_Localita { get; set; }
        string nome_sito { get; set; }
        string latitudine { get; set; }
        string longitudine { get; set; }
    }

    class FreeDive
    {
        int ID { get; set;}
        int ProgressiveNumber { get; set;}
        string DiveType { get; set;}
        string DiveStart { get; set;}
        int DiveLenghtTicks { get; set;}
        string Weather { get; set;}
        float AirTemperature { get; set;}
        string Current { get; set;}
        string Visibility { get; set;}
        string Note { get; set;}
        int ID_Subacqueo { get; set;}
        int ID_Sito { get; set;}
        int ID_Device { get; set;}
        string NomeSub { get; set;}
        int TotalElapsedSeconds { get; set;}
        int SampleRate { get; set;}
    }

    class FreeProfilePoint
    {
        int ID { get; set;}
        int ID_FreeDive { get; set;}
        int Sequence { get; set;}
        float Depth { get; set;}
        float Temperature { get; set;}
        int TimeTicks { get; set;}
        int ElapsedSeconds { get; set;}
    }
    class FreeDipStats
    {
        int ID { get; set; }
        int ID_FreeDive { get; set; }
        int SurfTime { get; set; }
        float MaxDepth { get; set; }
        int DipTime { get; set; }
        float TempMin { get; set; }
    }

}
