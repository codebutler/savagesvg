using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using Gtk;
using Glade;
using System.Reflection;
using System.Net;

public class GtkSharpVectorViewer
{
	public static void Main (string[] args)
	{
		Application.Init ();
		new GtkSharpVectorViewer (args);
		Application.Run ();
	}

	[Widget] ComboBoxEntry	addressComboBox;
	[Widget] TreeView 	testsTreeView;
	[Widget] HPaned		mainPaned;
	[Widget] HBox		mainHBox;
	[Widget] VBox		testsBox;
	[Widget] CheckMenuItem	viewTestsMenuItem;
	[Widget] CheckButton	showReferenceImageCheck;
	[Widget] Gtk.Image	referenceImage;
	
	SvgImageWidget svgWidget;
	TreeStore testsStore;
	
	public GtkSharpVectorViewer (string[] args)
	{
		XML glade = new XML (null, "svg-viewer.glade", "MainWindow", null);
		glade.Autoconnect (this);
		
		glade["bgEventBox"].ModifyBg(StateType.Normal, glade["MainWindow"].Style.Background (Gtk.StateType.Active));

		svgWidget = new SvgImageWidget();
		
	//	mainPaned.Add2 (svgWidget);
	//	mainPaned.Pack2 (svgWidget, false, false);
	//	mainHBox.PackStart (svgWidget, true, true, 0);
		
		(glade["svgViewport"] as Viewport).Add(svgWidget);
		
		svgWidget.Show();
		
		testsStore = new TreeStore(typeof(string));
		testsTreeView.Model = testsStore;
		testsTreeView.AppendColumn("Test Name", new CellRendererText(), "text", 0);
		
		if (args.Length > 0) {
			LoadUri (new Uri(args[0]));
		}
		 
		AddW3CTests ();
		
	}
	
	private void LoadUri (Uri uri)
	{
		addressComboBox.Entry.Text = uri.ToString();
		svgWidget.Load (uri.ToString());
		referenceImage.Visible = false;
	}
	
	private void viewTests_Activated (object sender, EventArgs args)
	{
		testsBox.Visible = viewTestsMenuItem.Active;
	}
	
	private void hideSidebarButton_clicked (object sender, EventArgs args)
	{
		//testsBox.Visible = false;
		viewTestsMenuItem.Active = false;
	}
	
	private void goButton_Clicked (object sender, EventArgs args)
	{
		try {
			LoadUri(new Uri(addressComboBox.Entry.Text));
		} catch (Exception ex) {
			//XXX: Show error dialog
			Console.WriteLine(ex);
		}
	}
	
	
	private void AddW3CTests()
	{
		string alltests = "";
		Assembly currentAssembly = Assembly.GetExecutingAssembly();
		using (Stream stream = currentAssembly.GetManifestResourceStream("w3ctests.txt")) {
			StreamReader reader = new StreamReader (stream);
			alltests = reader.ReadToEnd();
		}
		
		string[] tests = alltests.Split('\n');
		for (int i = 0; i < tests.Length; i++) {
			string test = tests[i].Trim();
			if (test.Length > 0) {
				testsStore.AppendValues (test);
			}
		}
	}
	 
	private void testsTreeView_RowActivated(object sender, RowActivatedArgs args)
	{
		TreeIter iter;
		if (testsStore.GetIter(out iter, args.Path)) {
			string testName = (string)testsStore.GetValue (iter, 0);
			string urlBase = "http://www.w3.org/Graphics/SVG/Test/20030813/";

			string url = urlBase + "svggen/" + testName + ".svg";
			LoadUri(new Uri(url));
						
			if (showReferenceImageCheck.Active) {
				string pngUrl = urlBase + "png/full-" + testName + ".png";
				WebClient client = new WebClient();
				byte[] data = client.DownloadData(pngUrl);
				referenceImage.Pixbuf = new Gdk.Pixbuf (data);
			}
		}
	}
	
	private void showReferenceCheck_Clicked (object sender, EventArgs args)
	{
		referenceImage.Visible = (showReferenceImageCheck.Active);
	}
}
