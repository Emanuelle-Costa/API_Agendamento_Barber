import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {

  public clientes: any =[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getClientes();
  }

  public getClientes(): void {
    this.http.get('https://localhost:7101/api/clientes').subscribe(
      response => this.clientes = response,
      error => console.log(error)
    );

  }
}
