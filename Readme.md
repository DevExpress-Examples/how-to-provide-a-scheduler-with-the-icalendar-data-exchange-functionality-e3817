<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/SilverlightApplication1/MainPage.xaml) (VB: [MainPage.xaml](./VB/SilverlightApplication1/MainPage.xaml))
* [MainPage.xaml.cs](./CS/SilverlightApplication1/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/SilverlightApplication1/MainPage.xaml.vb))
<!-- default file list end -->
# How to provide a scheduler with the iCalendar data exchange functionality


<p>This example illustrates how to implement the iCalendar data exchange functionality for a scheduler control.</p>


<h3>Description</h3>

<p>To export and import appointment data in the iCalendar format, use the <strong>iCalendarExporter</strong> and <strong>iCalendarImporter</strong> classes respectively. Pass the scheduler storage accessed via the <strong>SchedulerControl.GetCoreStorage</strong> property to their constructors as a parameter.<br /> To perform a data exchange operation, execute the corresponding method - <strong>AppointmentExporter.Export</strong> or <strong>AppointmentImporter.Import</strong>.</p>

<br/>


