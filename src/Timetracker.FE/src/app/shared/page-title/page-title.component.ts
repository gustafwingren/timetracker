import { Component, OnInit } from '@angular/core';
import { filter, Subject } from 'rxjs';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-page-title',
  templateUrl: './page-title.component.html',
  styleUrls: ['./page-title.component.scss'],
  standalone: true,
  imports: [AsyncPipe],
})
export class PageTitleComponent implements OnInit {
  title$ = new Subject<string | undefined>();

  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  async ngOnInit() {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        this.title$.next(this.activatedRoute.snapshot.root.firstChild!.title);
      });
  }
}
