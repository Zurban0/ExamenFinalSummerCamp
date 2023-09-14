import { Component, SimpleChanges, OnChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { IPersona } from './persona';
import { IPersonaForm } from './persona-form';
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

  registrarPersona(): void {
    let personaForm = <IPersonaForm>{
      nombre: this.nombre,
      fechaNacimiento: this.fechaNacimiento,
      telefono: this.telefono,
      username: this.username,
      password: this.password
    };

    this.subPost = this.appService.postPersona(personaForm).subscribe({
      next: () => {},
      error: err => this.errorMessage = err,
    });
  }

  set setPersonas(personas: IPersona[]){
    this.listaPersonas = personas;
  }

  ngOnChanges(): void {
      this.updateHistorial();
  }

  updateHistorial():void{
    this.subGet = this.appService.getPersonas().subscribe({
      next: listaPersonas => {
        this.listaPersonas = listaPersonas;
      },
      error: err => this.errorMessage = err
    });

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
