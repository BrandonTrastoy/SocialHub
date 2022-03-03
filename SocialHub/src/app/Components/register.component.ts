import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApiResponse } from '../Services/user.service';
import { UserService } from '../Services/user.service';


@Component({
	selector: 'app-register',
	templateUrl: './register.component.html',
	styles: [
	]
})

export class RegisterComponent implements OnInit {

	response: ApiResponse | undefined;

	constructor(
		private userService: UserService,
	) { }

	ngOnInit(): void {
	}

	register(username: string, password: string) {
		this.userService.registerUser(username, password).subscribe(
			data => {
				this.response = data;
				console.log(this.response);
			},
			(error: HttpErrorResponse) => {
				if (error.status === 400)
					this.response = error.error;
				else
					throw error;
			});
	}
}
