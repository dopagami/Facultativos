import { Injectable } from '@angular/core';


@Injectable()
// tslint:disable-next-line:max-line-length
// todo. Meter aquí variables y funciones globales... Es importante ponerle el decorador Injectable para poder gestionar las dependencias en el constructor.
export class Globals {
    public readonly API_URL = 'http://mk22788p/api/Privilegios';

}
