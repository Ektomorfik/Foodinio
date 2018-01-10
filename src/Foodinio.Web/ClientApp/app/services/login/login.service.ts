import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { JwtDTO } from '../../models/DTO/JwtDTO';
import { LoginCommand } from '../../models/commands/LoginCommand';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class LoginService {

    constructor(
        private http: Http,
        @Inject('BASE_URL') private _baseUrl: string
    ) { }

    public async Post(login: LoginCommand): Promise<JwtDTO> {
        const response = await this.http.post(this._baseUrl + 'api/Login', login).toPromise();
        return response.json() as JwtDTO;
    }
}