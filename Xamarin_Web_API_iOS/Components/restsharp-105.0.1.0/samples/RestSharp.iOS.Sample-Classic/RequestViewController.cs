// 
//  Copyright 2012  abhatia
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using MonoTouch.Dialog;
using System.Threading.Tasks;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using nfloat = System.Single;
#endif


namespace RestSharp.iOS.Sample
{
	public class RequestViewController : DialogViewController
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
				results.Value = t.Result.Content;
				ReloadData();
			}, uiScheduler);
		}

		public RequestViewController()
			: base (new RootElement ("Requests"), true)
		{
			Root.UnevenRows = true;
		}

		private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
		
		private readonly LargeMultiLineElement results = new LargeMultiLineElement ("");

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var requestSection = new Section ("Requests") {
				new StringElement ("REST Request", StartRestRequestAsync),
			};

			var responseSection = new Section ("Response") {
				results
			};

			Root.Add (new[] { requestSection, responseSection });
		}

		class LargeMultiLineElement : StringElement, IElementSizing
		{
			const float Height = 200f;

			public LargeMultiLineElement (string text)
				: base ("", text)
			{
			}

			public override UITableViewCell GetCell (UITableView tv)
			{
				var cell = base.GetCell (tv);
				cell.DetailTextLabel.Lines = 0;
				cell.DetailTextLabel.LineBreakMode = UILineBreakMode.WordWrap;
				cell.DetailTextLabel.Font = UIFont.FromName ("TrebuchetMS", 12);
				cell.DetailTextLabel.TextAlignment = UITextAlignment.Left;	
				return cell;
			}

			public nfloat GetHeight (UITableView tableView, NSIndexPath indexPath)
			{
				return Height;
			}
		}
	}
}