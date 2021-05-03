import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ExportAsService, ExportAsConfig } from 'ngx-export-as';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy{
  title = 'covid';
  dtOptions: any = {};

  showTop10CasesRegions = true;
  showTop10CasesProvinces = false;
  top10Cases = [];
  top10CasesByRegion = [];

  downloadJsonHref;

  dtTrigger: Subject<any> = new Subject<any>();
  dtTriggerProvinces: Subject<any> = new Subject<any>();

  exportAsConfig: ExportAsConfig = {
    type: 'xml', // the type you want to download
    elementIdOrContent: 'tabletop10Cases', // the id of html/table element
  }


  constructor(private http: HttpClient, private sanitizer: DomSanitizer, private exportAsService: ExportAsService) {}


  ngOnInit(): void {
    // this.dtOptions.order
    this.dtOptions = {
      order: [],
      // Declare the use of the extension in the dom parameter
      dom: 'Bfrtip',
      // Configure the buttons
      buttons: [
        'copy',
        'print',
        'excel',
        'csv'
      ]
    };



    this.onGetCasesTop10();
  }

  onShowTop10CasesProvinces() : void {
    this.showTop10CasesRegions = false;
    this.showTop10CasesProvinces = true;
  }

  onRefresh(){
    window.location.reload();
  }

  onGetCasesTop10() {
    const url = 'http://localhost:50946/api/cases/casestop10';
    this.http.get<any[]>(url).toPromise()
    .then(x=> {
      // console.log(x);
      this.top10Cases = x;

      this.dtTrigger.next();

      this.generateDownloadJsonUri();

    })
    .catch(error => {
      alert('Something went wrong')
    });
  }


  onGetCasesTop10ByRegion(regionName: string) {
    this.onShowTop10CasesProvinces();

    const url = `http://localhost:50946/api/cases/casestop10byregion?region_name=${regionName}`;
    this.http.get<any[]>(url).toPromise()
    .then(x=> {
      console.log(x);
      this.top10CasesByRegion = x;

      this.dtTriggerProvinces.next();

      this.generateDownloadJsonUri();

    })
    .catch(error => {
      alert('Something went wrong')
    });
  }


  generateDownloadJsonUri() {
    let data: any;
    if(this.showTop10CasesRegions) data = this.top10Cases;
    if(this.showTop10CasesProvinces) data = this.top10CasesByRegion;

    var theJSON = JSON.stringify(data);
    // console.log(theJSON);
    var uri = this.sanitizer.bypassSecurityTrustUrl("data:text/json;charset=UTF-8," + encodeURIComponent(theJSON));
    this.downloadJsonHref = uri;
}

 export() {
   let table = '';
  if(this.showTop10CasesRegions) table = 'tabletop10Cases';
  if(this.showTop10CasesProvinces) table = 'tabletop10CasesByRegion';

  this.exportAsConfig.elementIdOrContent = table;
  // download the file using old school javascript method
  this.exportAsService.save(this.exportAsConfig, 'data').subscribe(() => {
    // save started
  });
  // // get the data as base64 or json object for json type - this will be helpful in ionic or SSR
  // this.exportAsService.get(this.config).subscribe(content => {
  //   console.log(content);
  // });
}

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
    this.dtTriggerProvinces.unsubscribe();
  }


}
