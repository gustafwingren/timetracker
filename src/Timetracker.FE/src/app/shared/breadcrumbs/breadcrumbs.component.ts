import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import {
  ActivatedRoute,
  NavigationEnd,
  Router,
  RouterLink,
} from '@angular/router';
import { BehaviorSubject, filter } from 'rxjs';
import { NgFor, NgClass, AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './breadcrumbs.component.html',
  styleUrls: ['./breadcrumbs.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  imports: [RouterLink, NgFor, NgClass, AsyncPipe],
})
export class BreadcrumbsComponent implements OnInit {
  breadcrumbs$ = new BehaviorSubject<{ label: string; url: string }[]>([]);

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private changeDetection: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        const breadcrumbs: { label: string; url: string }[] = [];
        let currentRoute: ActivatedRoute | null = this.activatedRoute.root;
        let url = '';

        do {
          const childrenRoutes = currentRoute.children;
          currentRoute = null;
          childrenRoutes.forEach(route => {
            if (route.outlet === 'primary' && route.snapshot.url.length > 0) {
              const routeSnapshot = route.snapshot;
              url +=
                '/' + routeSnapshot.url.map(segment => segment.path).join('/');
              breadcrumbs.push({
                label: route.snapshot.data['breadcrumb'],
                url: url,
              });
              currentRoute = route;
            }
          });
        } while (currentRoute);

        this.breadcrumbs$.next(breadcrumbs);
        this.changeDetection.detectChanges();
      });
  }
}
