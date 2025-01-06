using Basy.LethalCompany.Utilities;
using BasyFirstMod.Services.Logging;
using BasyFirstMod.Services.Pranking;
using GameNetcodeStuff;
using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace Basy.FirstMod.Services.Pranking.Pranks
{
    public class JokePrank : PrankBase
    {
        public override string Description => "To nebol tvoj flash";


        public override async Task ExecuteAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await httpClient.GetAsync("https://icanhazdadjoke.com/");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode is false)
            {
                throw new Exception($"Fetching joke failed. {content}");
            }

            var startToken = "\"joke\":\"";
            var endToken = "\",\"status\":";

            var startTokenIndex = content.IndexOf(startToken) + startToken.Length;
            var endTokenIndex = content.IndexOf(endToken);
            var joke = JsonConvert.DeserializeObject<JokeJsonDto>(content);
            HUDManager.Instance.DisplayTip("Dad yoke", joke.Joke);


        }

        public static string DecodeUnicode(string input)
        {
            return Regex.Replace(input, @"\\u([0-9A-Fa-f]{4})", m =>
            {
                // Convert the Unicode escape to the actual character
                return ((char)int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber)).ToString();
            });
        }

        private class JokeJsonDto
        {
            public string Id { get; set; }
            public string Joke { get; set; }
            public int Status { get; set; }
        }
    }
}
