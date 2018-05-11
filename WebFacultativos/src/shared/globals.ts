import { Injectable } from '@angular/core';


export const API_URL = 'http://mk22788p/api/Privilegios';
export const API_URL_ROOT = 'http://mk22788p/api';
export const API_URL_WEB = 'http://MK22788:81';

@Injectable()
export class Globals {

    constructor() { }

    // Función genérica para mostrar errors devueltos del Backend
    errorCodes(code: number) {
        switch (code) {
            case 409:
                alert('Conflicto. Este código ya existe');
                break;

            default:
                break;
        }

    }
}
