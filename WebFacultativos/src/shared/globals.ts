import { Injectable } from '@angular/core';

export const API_URL_ROOT = 'http://facultativosapi.ibermatica.com/api';
export const API_URL_WEB = 'http://facultativosapi.ibermatica.com';

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
