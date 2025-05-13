import { Component, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Child } from '../../models/child.model';
import { Gender } from '../../../../shared/enums/gender.enum';
import { BloodType } from '../../../../shared/enums/blood-type.enum';
import { ChildStatus } from '../../../../shared/enums/child-status.enum';
import { getEnumOptions } from '../../../../shared/utils/enum-utils';
import { FormErrorsComponent } from '../../../../shared/components/form-errors/form-errors.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ChildService } from '../../services/child.service';
import { futureDateValidator } from '../../../../shared/validators/future-date.validator';

@Component({
  selector: 'app-child-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormErrorsComponent ],
  templateUrl: './child-form.component.html'
})
export class ChildFormComponent {
  @Input() initialData: Child | null = null;

  childForm!: FormGroup;
  backendErrors: any;

  errorMessages = {
    required: 'This field is required.',
    minlength: 'This field must be at least 2 characters long.',
  };

  genderEnum = getEnumOptions(Gender);
  bloodTypeEnum = getEnumOptions(BloodType);
  childStatusOptions = getEnumOptions(ChildStatus);

  isEditMode: Boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private childService: ChildService
  ) {
    
    this.childForm = this.fb.group({
      id: [''],
      fullName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      dateOfBirth: ['', [Validators.required, futureDateValidator()]],
      allergies: ['', [Validators.maxLength(250)]],
      gender: ['', [Validators.required]],
      status: [''],
      bloodType: [''],
      address: ['', [Validators.maxLength(200)]],
      notes: ['', [Validators.maxLength(300)]]
    });
  }

  ngOnInit() {
    this.LoadChild();
  }

  private LoadChild() {
    if (this.initialData) {
      this.isEditMode = true;
      this.childForm.patchValue(this.initialData);
    } 
    else {
      this.isEditMode = false;
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialData']) {
      this.LoadChild();
    }
  }

  
  public setServerErrors(errors: { [key: string]: string[] }) {
    for (const [field, messages] of Object.entries(errors)) {
      const control = this.childForm.get(field);
      if (control) {
        control.setErrors({ server: messages.join(', ') });
      }
    }
  }


  onSubmit() {
    if (this.childForm.invalid) {
      this.childForm.markAllAsTouched(); // Trigger display of all validation errors
      return;
    }
  
    const child = this.childForm.value;
  
    if (this.initialData) {
      this.childService.update(child).subscribe({
        next: () => this.router.navigate(['/children']),
        error: (err) => this.handleServerError(err)
      });
    } else {
      child.id = 0;
      this.childService.create(child).subscribe({
        next: () => this.router.navigate(['/children']),
        error: (err) => this.handleServerError(err)
      });
    }
  }
  
  private handleServerError(err: any) {
    if (err.status === 400 && err.error?.errors) {
      this.backendErrors = err.error.errors;
      this.backendErrors = { ...err.error.errors };
    }
    else {
      this.backendErrors = err?.error;
      this.backendErrors = { ...err.error };
    }
  }

}
