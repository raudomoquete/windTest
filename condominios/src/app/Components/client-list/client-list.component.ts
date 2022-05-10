import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CondominiosService } from 'src/app/Services/condominios.service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  constructor(public condominioService: CondominiosService,
              ) { }

  ngOnInit(): void {
    this.condominioService.GetClients();
    }

  deleteClient(id: number) {
    this.condominioService.deleteClient(id).subscribe(data => {
      this.condominioService.GetClients();
    });
  }

   edit(client: any) {
    this.condominioService.update(client);
  }
}