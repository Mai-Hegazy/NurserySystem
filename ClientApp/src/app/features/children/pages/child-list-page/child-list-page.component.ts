import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Child } from '../../models/child.model';
import { ChildService } from '../../services/child.service';
import { BloodType } from '../../../../shared/enums/blood-type.enum';

@Component({
  selector: 'app-child-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './child-list-page.component.html'
})
export class ChildListPageComponent implements OnInit {

  children: Child[] = [];

  constructor(
    private childService: ChildService) { }

  ngOnInit() {
    this.loadChildren();
  }

  loadChildren() {
    this.childService.getChildren()
      .subscribe(data => this.children = data);
  }

  getReadableBloodType(key: string): string {
    if (!key) return '-';
    return BloodType[key as keyof typeof BloodType] ?? key;
  }

  deleteChild(id: number) {
    if (confirm("Are you sure?")) {
      this.childService.delete(id)
        .subscribe(() => this.loadChildren);
    }
  }

}
