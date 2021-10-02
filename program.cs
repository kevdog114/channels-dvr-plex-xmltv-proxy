using System;
using System.Net.Http;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using Microsoft.AspNetCore.Builder;

var app = WebApplication.CreateBuilder(args).Build();
	    
var ENV_M3U_SOURCE   = Environment.GetEnvironmentVariable("M3U_SOURCE");
var ENV_XMLTV_SOURCE = Environment.GetEnvironmentVariable("XMLTV_SOURCE");

app.MapGet("/api/m3u", async () => {
	var client = new HttpClient();
	var s = await client.GetStringAsync(ENV_M3U_SOURCE);
	return s.Replace("channel-id", "tvg-id");
});

app.MapGet("/api/xmltv", async () => {

	var client = new HttpClient();

	int days = 7;
	int seconds = days * 24 * 60 * 60;
	using (var ms = await client.GetStreamAsync(ENV_XMLTV_SOURCE))
	{
		var x = XElement.Load(ms);
		var programs = x.Descendants("programme").Select(x => x);
	
		foreach(var p in programs)
		{
			var isNew = p.Element("new");
			if(isNew != null)
			{
				isNew.Remove();
			}
			else
			{
				p.Add(new XElement("previously-aired"));
				p.Add(new XElement("previously-shown"));
			}
	
		}
		return x.ToString();
	
	}

});

app.Run();
