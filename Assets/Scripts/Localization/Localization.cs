using System.Collections.Generic;
using UnityEngine;
using System;

public enum Locale
{
    //english and portuguese
    en, pt, es
}

public static class Localization
{
    //Its going to load resources within Unity and disect a CSV format - dissect that and give us a dictionary and return the 
    //Create a dictionary for English and another one for pt

    private static Dictionary<Locale, Dictionary<string, string>> s_localizationTable;

    // this is the variable you change when wanting to shift the language of your application
    public static Locale s_currentLocale = Locale.en;

    // this is the one that gives you the functional dictionary you can use for your announcements in the current language selected
    public static Dictionary<string, string> s_currentLocalizationTable => s_localizationTable[s_currentLocale];
    // => is made so it updates, its a lambda function, so it executes when it needs to be executed.


    static Localization()
    {
        // a constructor uses the same method name as the class, and when the class is constructed, the constructor immediately is activated.
        Load();
    }



    private static void Load()
    {
        var source = Resources.Load<TextAsset>("LocalizationSource1");
        var lines = source.text.Split('\n');


        var header = lines[0].Split(';'); // ["", "en", "pt"]
        //string toprint = "";
        //foreach(var i in header)
        //{
        //    toprint += (" " + i);
        //}
        //Debug.Log(header.length);


        var localeOrder = new List<Locale>(header.Length - 1);

        s_localizationTable = new Dictionary<Locale, Dictionary<string, string>>();

        for (int i = 1; i < header.Length; i++)
        {
            // type casting as Locale enum
            var locale = (Locale)Enum.Parse(typeof(Locale), header[i]);

            localeOrder.Add(locale);
            s_localizationTable[locale] = new Dictionary<string, string>(lines.Length - 1);
            //s_localizationTable[locale] = new Dictionary<string, string>(18);
        }

        for(int index = 1; index < lines.Length; index++)
        {
            // obtain the first column element and assign it to key
            var entry = lines[index].Split(';');
            var key = entry[0];
            
            for(var i = 0; i < localeOrder.Count; i++)
            {
                i = i;
                var locale = localeOrder[i];
                Debug.Log($"gone {i}");
                s_localizationTable[locale][key] = entry[i + 1];
            }
        }
         

    }



}

