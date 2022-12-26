namespace FicheDUE.Constants
{
	public static class ConfigConstants
	{
		public static string GetAuthApiURL(IConfiguration config)
		{
			return config.GetSection("URLApi").GetSection("url").Value;
		}
	}
}
	