namespace FicheDUE.Constants
{
	public static class ConfigConstants
	{
		public static string GetAuthApiURL(IConfiguration config)
		{
			return config.GetSection("URLApi").GetSection("URL").Value;
		}

		public static string GetUEApiUrl(IConfiguration config)
		{
			return config.GetSection("URLApiGestion").GetSection("URL").Value;
		}
	}
}
	