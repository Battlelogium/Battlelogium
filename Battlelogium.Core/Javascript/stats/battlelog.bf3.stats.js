var match = window.location.href.match(/battlereport\/show\/([0-9]+)\/([0-9]+)\//);
var e = $("#battlereport h1:first");
var reportId = match[2];
var format = match[1];
var platform = BBLog.deviceInfo[format];
if(platform == "xbox") platform = "360";
var html = $(
    '<span id="bf3stats-report" class="bblog-button bblog-report-buttons bf3stats">Bf3stats.com Battlereport</span>'
);
html.on("click", function(){
    window.open('http://bf3stats.com/report/'+platform+'/'+reportId);
});
e.after(html);

