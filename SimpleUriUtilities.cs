/**
 * SimpleUriUtilities
 * Copyright (c) Simon Raichl 2021
 * MIT License
 */

using System.Linq;
using System.Collections.Generic;

public class SimpleUriUtilities
{
    public Dictionary<string, string> GetQueryParameters(string url) 
    {
        Dictionary<string, string> queryParameters = new Dictionary<string, string>();

        if (!url.Contains("?")) 
        {
            return queryParameters;
        }

        string parameters = url.Substring(url.IndexOf("?") + 1);

        foreach (string queryParameter in parameters.Split('&')) 
        {
            if (!queryParameter.Contains("="))
            {
                AddQueryParameterToDictionary(queryParameters, queryParameter, "");
            }
            else 
            {
                string[] keyValuePair = queryParameter.Split('=');
                AddQueryParameterToDictionary(queryParameters, keyValuePair.First(), keyValuePair.Last());
            }
        }

        return queryParameters;
    }

    private void AddQueryParameterToDictionary(Dictionary<string, string> queryParameters, string key, string value)
    {
        if (!queryParameters.ContainsKey(key) && key.Length > 0)
        {
            queryParameters.Add(key, value);
        }
    }
}
