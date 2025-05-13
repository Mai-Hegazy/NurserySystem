import { CommonModule } from '@angular/common';
import {  Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-form-errors',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './form-errors.component.html',
  styleUrl: './form-errors.component.css'
})
export class FormErrorsComponent implements  OnInit, OnChanges {
  @Input() formGroup: FormGroup | null = null;
  @Input() customMessages: { [key: string]: string } = {};
  @Input() backendErrors: any;

  formControls: {name: string, control: AbstractControl}[] = [];
  generalBackendErrors: string[] = [];

  ngOnInit() {
    this.setFormControls();
    this.setGeneralErrors();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['backendErrors']) {
      this.setGeneralErrors();
    }
    if (changes['formGroup']) {
      this.setFormControls();
    }
  }

  private setFormControls() {
    if (this.formGroup) {
      this.formControls = Object.entries(this.formGroup.controls).map(([name, control]) => ({ name, control }));
  }
  }

  private setGeneralErrors() {
    if (this.backendErrors && typeof this.backendErrors === 'object') {
      // Filter out field-specific errors by checking if the key exists in the form
      const fieldKeys = this.formGroup ? Object.keys(this.formGroup.controls) : [];
      this.generalBackendErrors = Object.entries(this.backendErrors)
        .filter(([key]) => !fieldKeys.includes(key))
        .flatMap(([_, value]) => (Array.isArray(value) ? value : [value]));
    } else if (typeof this.backendErrors === 'string') {
      this.generalBackendErrors = [this.backendErrors];
    } else {
      this.generalBackendErrors = [];
    }
  }

  errorMessages(control: AbstractControl): string[] {
    if (!control || !control.errors) {
      return [];
    }

    return Object.keys(control.errors).map((errorKey) => {
      return this.customMessages[errorKey] || this.defaultErrorMessage(errorKey);
    });
  }

  hasGeneralErrors(): boolean {
    return this.generalBackendErrors.length > 0;
  }

  private defaultErrorMessage(errorKey: string): string {
    const errorMessages: { [key: string]: string } = {
      required: 'This field is required.',
      minlength: 'Minimum length not met.',
      maxlength: 'Maximum length exceeded.',
      pattern: 'Invalid format.',
      email: 'Invalid email address.',
      futureDate: 'Date cannot be in the future.'
    };

    return errorMessages[errorKey] || 'Invalid input';
  }

  formatLabel(name: string): string {
    return name
      .replace(/([A-Z])/g, ' $1') // Add space before capital letters
      .replace(/^./, str => str.toUpperCase()); // Capitalize first letter
  }
  
}
