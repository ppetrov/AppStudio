using System.Threading.Tasks;
using AppCore.Localization;

namespace AppCore.Dialog
{
	/// <summary>
	/// Allow to display information messages or confirmation ones
	/// </summary>
	public interface IDialogManager
	{
		/// <summary>
		/// Display the message
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		Task DisplayAsync(LocalMessage message);

		/// <summary>
		/// Confirms the message
		/// </summary>
		/// <param name="message"></param>
		/// <param name="confirmationType"></param>
		/// <returns></returns>
		Task<ConfirmationResult> ConfirmAsync(LocalMessage message, ConfirmationType confirmationType);
	}
}