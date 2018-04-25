import { KeycloakService } from 'keycloak-angular';


export function initializer(keycloak: KeycloakService): () => Promise<any> {
  return (): Promise<any> => {
    return new Promise(async (resolve, reject) => {
      try {
        await keycloak.init({
          config: {
            url: 'http://mk22788p:8081/auth',
            realm: 'PruebaRealm',
            clientId: 'demo-app',
            'credentials': {
              'secret': '5b834700-2f8a-4622-bb51-9eb80a5f52dd'
            }
          },
          initOptions: {
            onLoad: 'login-required',
            checkLoginIframe: false
          },
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


