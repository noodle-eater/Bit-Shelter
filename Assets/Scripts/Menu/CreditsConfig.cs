using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreditsConfig", menuName = "Bit Shelter/CreditsConfig", order = 0)]
public class CreditsConfig : ScriptableDB<CreditData> {
    

    [SerializeField]
    private string creditHeader;
    [SerializeField]
    private string myCreditText;
    [SerializeField]
    [TextArea] private string creditFormat;

    public static CreditsConfig Load(string fileName = "CreditsConfig") {
        return Resources.Load<CreditsConfig>(fileName);
    }

    public List<CreditData> GetCredits() {
        return database;
    }

    public override string ToString() {
        var credits = string.Empty;
        credits += creditHeader + "\n";
        credits += myCreditText + "\n";
        
        // foreach(var item in database) {
        //     var temp = creditFormat;
        //     temp = temp.Replace()
        // }

        return credits;
    }
}

[System.Serializable]
public class CreditData {
    public string assetName;
    public string creator;
    [TextArea]
    public string desc;
}