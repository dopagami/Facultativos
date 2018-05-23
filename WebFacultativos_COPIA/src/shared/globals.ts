import { Injectable } from '@angular/core';

export const API_URL_ROOT = 'http://keycloakserver/api';
export const API_URL_WEB = 'http://keycloakserver:81';

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
