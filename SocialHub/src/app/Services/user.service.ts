import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'

const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json'
	})
}

export class ApiResponse {
	data!: string;
	success!: boolean;
	message!: string;
}

@Injectable({
	providedIn: 'root'
})

export class UserService {

	private apiUrl = "https://localhost:44319/user";

	constructor(private http: HttpClient) {
	}

	registerUser(username: string, password: string): Observable<ApiResponse> {
		return this.http.post<ApiResponse>(this.apiUrl + '/register', { username: username, password: password });
	}

	loginUser(username: string, password: string): Observable<ApiResponse> {
		return this.http.post<ApiResponse>(this.apiUrl + '/login', { username: username, password: password });
	}
}
