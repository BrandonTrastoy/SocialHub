import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Routes, Router } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { UserService } from '../Services/user.service';
import { ApiResponse } from '../Services/user.service';
import { DataService } from '../Services/data.service';
//import { ApplicationException, CommonService } from '../../Services/common.service';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styles: [
	]
})
export class LoginComponent implements OnInit {

	response: ApiResponse | undefined;
	loginForm!: FormGroup;
	submitted: boolean = false;

	private routes!: Routes;

	constructor(
		private userService: UserService,
		private data: DataService,
		private router: Router,
		//private commonService: CommonService
	) { }

	ngOnInit(): void {
		this.loginForm = new FormGroup({
			username: new FormControl('', [Validators.required, Validators.minLength(4)]),
			password: new FormControl('', [Validators.required, Validators.minLength(4)])
		});
	}

	login(username: string, password: string) {
		this.data.homePageBusy = true; // Show a spinner when busy
		this.submitted = true;

		if (!this.isFormInvalid()) {
			// Any data outside of this subscribe will not run synchronously
			this.userService.loginUser(username, password).subscribe({
				next:
					data => {
						this.data.homePageBusy = false;
						this.response = data;
						this.data.updateResponse(data);

						if (this.response != undefined && this.response.success) {
							//this.router.navigate(['/UserHomepage']);
							console.log("Login success and navigate")
						}
					},
				error:
					(error: HttpErrorResponse) => {
						console.log(error);
						//this.commonService.setAppException(
						//  {
						//    Message: error.message,
						//    Status: error.status,
						//    URL: error.url
						//  } as ApplicationException
						//);
					}

			});
		}
	}

	isFieldInvalid(field: string) {
		return (this.loginForm.get(field)!.invalid && this.loginForm.get(field)!.dirty && this.loginForm.get(field)!.touched);
	}

	isFormInvalid() {

		var usernameString = 'username';
		var passwordString = 'password';

		return (this.isFieldInvalid(usernameString) || this.isFieldInvalid(passwordString)) ||
			(this.submitted && (this.loginForm.get(usernameString)!.value == "" || this.loginForm.get(passwordString)!.value == ""));
	}

}
