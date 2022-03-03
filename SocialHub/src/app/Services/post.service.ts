import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'

const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json'
	})
}

export class ApiResponse<T> {
	Data!: T;
	Success!: boolean;
	Message!: string;
}

export class UserPost {
	postId!: number;
	text!: string;
}

export class Post {
	postId!: number;
	username!: string
	text!: string;
}

@Injectable({
	providedIn: 'root'
})
export class PostService {

	private apiUrl = "https://localhost:44319/post";

	constructor(private http: HttpClient) {
	}

	getUserPosts(userId: number): Observable<ApiResponse<UserPost[]>> {
		return this.http.get<ApiResponse<UserPost[]>>(this.apiUrl + '/' + userId);
	}

	getAllPosts(): Observable<ApiResponse<Post[]>> {
		return this.http.get<ApiResponse<Post[]>>(this.apiUrl + '/all');
	}

	createNewPost(content: string, id: number): Observable<ApiResponse<number>> {
		return this.http.post<ApiResponse<number>>(this.apiUrl + '/create', { text: content, userid: id });
	}

	updatePost(content: string, postId: number, userId: number): Observable<ApiResponse<UserPost>> {
		return this.http.put<ApiResponse<UserPost>>(this.apiUrl + '/update', { text: content, userid: userId, postid: postId });
	}

	deletePost(postId: number): Observable<ApiResponse<number>> {
		return this.http.delete<ApiResponse<number>>(this.apiUrl + '/' + postId);
	}
}
