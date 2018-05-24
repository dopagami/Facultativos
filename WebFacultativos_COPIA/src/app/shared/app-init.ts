import { KeycloakService } from 'keycloak-angular';

// Creamos un Interceptor.  Es un tipo de Middleware que actúa de proxy entre el cliente y el servidor.
// Añadimos funcionalidades genéricas a nuestra comunicación HTTP. Enviaremos en cada petición http el token de usuario.
export function initializer(keycloak: KeycloakService): () => Promise<any> {
  return (): Promise<any> => {
    return new Promise(async (resolve, reject) => {
      try {
        await keycloak.init({
          config: {
            url:  'http://keycloakserver:8081/auth',
            realm: 'PruebaRealm',
            clientId: 'demo-app',
            'credentials': {
              'secret': '5b834700-2f8a-4622-bb51-9eb80a5f52dd'
            }
          },
          initOptions: {
            onLoad: 'login-required',
            checkLoginIframe: true
          },
          // Aquí incluiremos las urls que queremos que no envíen Token en el header
          bearerExcludedUrls: [
            '/assets',
            '/clients/public'
          ],
        });
        resolve();
      } catch (error) { }
    });
  };
}


