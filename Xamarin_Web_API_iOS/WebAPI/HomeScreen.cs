using MonoTouch.UIKit;
using System.Collections.Generic;
using RestSharp;

namespace XamarinWebAPI
{
    public class HomeScreen : UIViewController 
    {
        UITableView table;


		/// <summary>
		/// Draw a table as soon as the page is loaded
		/// </summary>
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			BuildTable (); 

			// Only one of these can be active at a time
//            LoadDataFromStarWarsAPI();
			LoadDataFromWebAPI();
        }



		void BuildTable ()
		{
			table 				   = new UITableView (View.Bounds);
			table.AutoresizingMask = UIViewAutoresizing.All;  // defaults to Plain style. Other option is Grouped

			var tableSource = new TableSource<Person> ();

				// Event handler for what happens when we click on the item in a row
				tableSource.OnRowSelected += (object sender, TableSource<Person>.RowSelectedEventArgs e) =>  {
											  new UIAlertView ("Row Selected", tableSource.Data [e.indexPath.Row].ToString (), null, "OK", null).Show ();
											  e.tableView.DeselectRow (e.indexPath, true);
											  };
			table.Source = tableSource;

			// Adds subviews to the table
			Add (table);
		}


		/// <summary>
		/// Loads the data from star wars API.
		/// </summary>
		void LoadDataFromStarWarsAPI()
		{
			var request 		    = new RestRequest {};
				request.Resource    = "/people/";
				request.RootElement = "results";

			var client  = new RestClient("http://swapi.co/api");
				client.ExecuteAsync<List<Person>> (request, response => InvokeOnMainThread (delegate {

				// pass the data to the TableSource class
				((TableSource<Person>)table.Source).Data = response.Data;

				// make the TableView reload the data
				table.ReloadData ();
			}));
		}


		/// <summary>
		/// Loads the data from our custom ASP.NET Web API
		/// </summary>
		void LoadDataFromWebAPI()
		{
			var request 	 = new RestRequest {};
			request.Resource = "/api/apiperson";

			var client  = new RestClient("http://xamarinwebapi.azurewebsites.net/");
				client.ExecuteAsync<List<Person>> (request, response => InvokeOnMainThread (delegate {

				// pass the data to the TableSource class
				((TableSource<Person>)table.Source).Data = response.Data;

				// make the TableView reload the data
				table.ReloadData ();
			}));
		}


    }
}
