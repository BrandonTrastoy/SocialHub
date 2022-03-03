import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { ApiResponse } from './user.service';

@Injectable({
	providedIn: 'root'
})
export class DataService {

	private response = new BehaviorSubject<ApiResponse>({ data: "", success: false, message:"" });
	currentResponse = this.response.asObservable();

	public homePageBusy: boolean = false;

	constructor() { }

	updateResponse(newResponse: ApiResponse) {
		this.response.next(newResponse);
	}

}
