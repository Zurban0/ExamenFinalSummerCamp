import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { IPersona } from './persona';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ExamenPedroAngular';
  username! : string
  password! : string
  nombre! : string
  fechaNacimiento! : Date
  telefono! : string

  listaPersonas: IPersona[] = []
  errorMessage: string = ''
  subGet!: Subscription
  subPost!: Subscription

  constructor(private appService: AppService) {}

  registraPersona(): void {
    let persona = <IPersona>{
      nombre: this.nombre,
      fechaNacimiento: this.fechaNacimiento,
      telefono: this.telefono,
      username: this.username,
      password: this.password
    };

    
  }

  ngOnInit(): void {
    this.subGet = this.appService.getPersonas().subscribe({
      next: listaPersonas => {
        this.listaPersonas = listaPersonas;
      },
      error: err => this.errorMessage = err
    });
}

  ngOnDestroy(): void {
      this.subGet.unsubscribe();
      this.subPost.unsubscribe();
  }
}
