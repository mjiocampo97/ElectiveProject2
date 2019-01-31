using System;
using System.IO;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;
using OcampoElective2Project.Services;
using OcampoElective2Project.Views;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace OcampoElective2Project
{
	public partial class App : Application
	{
	 
        public static ViewModelLocator Locator;
	    private static ViewModelLocator _locator;
        private readonly InitializeData InitializeData;
	    private readonly InitializeNavigation initNavigation;
	    public static NavigationService NavigationService { get; set; }
        //public IDataService<T> IDataService;
        public App ()
		{        
		    

            InitializeComponent();
		    if (initNavigation == null)
		    {
		        initNavigation = new InitializeNavigation();
		    }
		    Locator = _locator ??new ViewModelLocator();
          //  InitializeData = new InitializeData();
		    NavigationService = initNavigation.navigationService;
           // initNavigation.SetPages();
		   // var firstPage = new NavigationPage(new LogInPage());
		   // initNavigation.navigationService.Initialize(firstPage);
		  //  MainPage = firstPage;
		    MainPage = initNavigation.SetMasterDetailMainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
