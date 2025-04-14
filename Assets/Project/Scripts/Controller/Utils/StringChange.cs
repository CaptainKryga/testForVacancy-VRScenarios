namespace Project.Scripts.Controller.Utils
{
	// Setting up strings
	public class StringChange
	{
		// Change string color
		public string SetColorFromString(string text, string color)
		{
			return $"<color={color}>{text}</color>";
		}
	}
}