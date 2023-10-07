using System.Windows;
using System.Windows.Controls;

namespace HeadHunterAnalyzer.Desktop.Views.Behaviors {
	
    public static class BrowserBehavior {

		public static readonly DependencyProperty HtmlProperty = DependencyProperty
			.RegisterAttached("Html", typeof(string), typeof(BrowserBehavior), new FrameworkPropertyMetadata(OnHtmlChanged));
		

		[AttachedPropertyBrowsableForType(typeof(WebBrowser))]
		public static string GetHtml(WebBrowser browser) => (string)browser.GetValue(HtmlProperty);

		public static void SetHtml(WebBrowser browser, string value) => browser.SetValue(HtmlProperty, value);

		private static void OnHtmlChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args) {

			WebBrowser browser = depObj as WebBrowser;
			if (browser != null && args.NewValue != null)
				browser.NavigateToString(args.NewValue as string);
		}
	}
}
