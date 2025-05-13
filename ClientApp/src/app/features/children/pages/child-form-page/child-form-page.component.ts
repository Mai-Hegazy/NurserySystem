import { Child } from './../../models/child.model';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ChildFormComponent } from '../../components/child-form/child-form.component';
import { ChildService } from '../../services/child.service';

@Component({
  selector: 'app-child-form-page',
  standalone: true,
  imports: [CommonModule, ChildFormComponent],
  templateUrl: './child-form-page.component.html',
})
export class ChildFormPageComponent {
  child: Child | null = null;

  constructor(
    private route: ActivatedRoute,
    private childService: ChildService
  ) { }

  ngOnInit() {
    const childId = this.route.snapshot.paramMap.get('id');
    if (childId) {
      this.childService.getById(+childId).subscribe(c => {
        this.child = c;
        this.child.dateOfBirth = c.dateOfBirth?.slice(0, 10);
      });
    }
    else {
      this.child = null;
    }
  }

}

