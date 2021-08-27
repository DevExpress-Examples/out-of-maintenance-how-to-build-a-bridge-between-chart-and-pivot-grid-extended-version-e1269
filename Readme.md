<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1269)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Form2.cs](./CS/Form2.cs) (VB: [Form2.vb](./VB/Form2.vb))
* [SimpleDataSet.cs](./CS/SimpleDataSet.cs) (VB: [SimpleDataSet.vb](./VB/SimpleDataSet.vb))
<!-- default file list end -->
# How to build a bridge between chart and pivot grid: Extended version


<p><strong>Note: This example applies to an XtraCharts version prior to v2010 vol 2. Starting from v2010 vol 2,  after you assign a Pivot Grid instance to your chart's DataSource property, all the chart's bindings and layout settings are automatically adjusted.  For more information, please review the </strong><a href="https://www.devexpress.com/Support/Center/p/S90521">S90521: Improve the interaction between the XtraCharts and XtraPivotGrid controls</a><strong> report and  </strong><a href="https://www.devexpress.com/Support/Center/p/E4983">E4983</a><strong> example.</strong></p><p></p><p>This example is an extended version of the <a href="https://www.devexpress.com/Support/Center/p/E284">E284</a> example. Due to numerous client requests regarding this functionality, we've decided to create a complete sample project, visually demonstrating different ChartControl-PivotGridControl relation approaches. </p>


<h3>Description</h3>

<p>You can see how it works in action. Briefly, you can change such options as &quot;SelectionOnly&quot;, &quot;ChartDataVertical&quot; and &quot;ChartDataSourceType&quot; directly from the menu of the main form at runtime. Data will be regenerated and repainted immediately. So, you&#39;ll be able to review how these parameters affect the resulting data. In addition, you&#39;ll be able to review the actual DataTable generated from the PivotGridControl. This will help better understand the ChartControl-PivotGridControl relation. Finally, we&#39;ve implemented the Drill Down feature in this example. We hope that you will find this functionality useful.</p>

<br/>


