import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule, FormGroup, Validators } from '@angular/forms';
import { UserService, AuthenticationService } from '@/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    loginForm: FormGroup;
    currentUser: any;
    users = [];
    public goldprice: number;
    public weight: number;
    public totalprice;
    public IsFilePrint: boolean = false;

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private router: Router,
    ) {

        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {

        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    calculate() {

        this.totalprice = this.goldprice * this.weight;
        if (this.currentUser.isPriviledgedUser) {
            this.totalprice = this.totalprice - (this.totalprice * 2 / 100);
        }
    }
    CheckDisabled() {

        return (this.goldprice == 0 || this.goldprice == undefined || this.weight == 0 || this.weight == undefined || this.totalprice == 0 || this.totalprice == undefined);
    }

    PrinttoFile() {
        this.IsFilePrint = true;
        this.PrintServiceCall();

    }
    PrintToScreen() {
        this.IsFilePrint = false;
        alert('Gold Price: ' + this.goldprice + ' Weight: ' + this.weight + ' Total Price: ' + this.totalprice);
    }
    PrintTopaper() {
        this.IsFilePrint = false;
        this.PrintServiceCall();
    }


    PrintServiceCall() {
        this.authenticationService.print(this.goldprice, this.weight, this.totalprice, this.IsFilePrint)
            .pipe(first())
            .subscribe(
                data => {
                    this.IsFilePrint = data;
                    if (this.IsFilePrint)
                        alert("Print Succeed")
                });
    }

}