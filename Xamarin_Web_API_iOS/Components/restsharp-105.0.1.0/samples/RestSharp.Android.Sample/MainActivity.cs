using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RestSharp.Android.Sample
{
	[Activity(Label = "RestSharp.Android.Sample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private readonly RestClient restClient = new RestClient (@"http://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/");
		private void StartRestRequestAsync()
		{
			Task.Factory.StartNew (() => {
				var rxcui = "198440";
				var request = new RestRequest (String.Format ("{0}/allinfo", rxcui));
				request.RequestFormat = DataFormat.Json;

				return this.restClient.Execute (request);
			}).ContinueWith (t => {
				text.Text = t.Result.Content;
			}, uiScheduler);
		}

		private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
		private TextView text;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			text = FindViewById<TextView> (Resource.Id.Text);

			FindViewById<Button> (Resource.Id.Request).Click += (s, e) => StartRestRequestAsync();
		}
	}
}

