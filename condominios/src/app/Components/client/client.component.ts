import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Client } from 'src/app/models/client';
import { CondominiosService } from 'src/app/Services/condominios.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit, OnDestroy {
  form: FormGroup;
  suscription!: Subscription;
  client!: Client;
  idClient = 0;

  constructor(private formBuilder: FormBuilder,
              private condominioService: CondominiosService,
              public route: ActivatedRoute,) { 
    this.form = this.formBuilder.group({
      id: 0,
      firstName!: [''],
      lastName!: [''],
      email!: [''],
      phone!: [''],
    })
  }

  ngOnInit(): void {
  /*   this.suscription = this.condominioService.getClient$().subscribe(data => {
      console.log(data);
      this.client = data;
      this.form.patchValue({
        firstName: this.client.firstName,
        lastName: this.client.lastName,
        email: this.client.email,
        phone: this.client.phone
      });
      this.idClient == this.client.id;
    }); */
  }

  ngOnDestroy(){
    this.suscription.unsubscribe();
  }

  saveClient() {
    if (this.idClient === 0) {
      this.add();
    } else {
      this.edit();
    }
  }

  add() {
    const client: Client = {
      firstName: this.form.get('firstName')?.value,
      lastName: this.form.get('lastName')?.value,
      email: this.form.get('email')?.value,
      phone: this.form.get('phone')?.value,
    };

    this.condominioService.saveClient(client).subscribe(data => {
      this.condominioService.GetClients();
      this.form.reset();
    });
  }

  edit() {
    const client: Client = {
      id: this.client.id,
      firstName: this.form.get('firstName')?.value,
      lastName: this.form.get('lastName')?.value,
      email: this.form.get('email')?.value,
      phone: this.form.get('phone')?.value,
    };
    this.condominioService.updateClient(this.idClient, client).subscribe(data => {
      this.condominioService.GetClients();
      this.form.reset();
      this.idClient = 0;
    });
  }
}