# CareFlow API

A comprehensive healthcare management system built with ASP.NET Core, providing role-based access control for patients, doctors, and administrators.

## 🏥 Overview

CareFlow API is a robust healthcare management platform that facilitates:
- Patient registration and profile management
- Doctor appointment scheduling
- Prescription and medical history management
- Document storage and retrieval
- Review and rating system
- Multi-role authorization system

## 🚀 Features

### Core Functionality
- **Patient Management** - Registration, profiles, medical histories
- **Doctor Management** - Profiles, specializations, appointment tracking
- **Appointment System** - Scheduling, filtering, status management
- **Prescription Management** - Medicine prescriptions with detailed instructions
- **Document Management** - Secure file upload/download system
- **Review System** - Patient feedback and doctor ratings

### Security & Authorization
- **JWT Authentication** - Secure token-based authentication
- **Role-Based Access Control** - Admin, Doctor, Patient roles
- **Resource-Level Security** - Users can only access their own data

## 🏗️ API Structure

### Authentication Endpoints
```
POST /api/auth/register/patient     # Patient registration
POST /api/auth/register/doctor      # Doctor registration  
POST /api/auth/token               # Login/token generation
```

### Core Resources
```
# Patients
GET    /api/patients               # List patients (Admin/Doctor)
GET    /api/patients/{id}          # Get patient (Admin)
PUT    /api/patients               # Update patient (Admin)
DELETE /api/patients               # Delete patient (Admin)

# Doctors
GET    /api/doctors                # List doctors
GET    /api/doctors/{id}           # Get doctor details
PUT    /api/doctors                # Update doctor (Admin)
DELETE /api/doctors/{id}           # Delete doctor (Admin)

# Appointments
GET    /api/appointments           # List appointments (Patient/Doctor)
GET    /api/appointments/{id}      # Get appointment details
POST   /api/appointments           # Create appointment
PUT    /api/appointments           # Update appointment
DELETE /api/appointments/{id}      # Cancel appointment
```

### Nested Resources
```
# Patient Allergies
GET    /api/patients/{patientId}/allergies
POST   /api/patients/{patientId}/allergies
DELETE /api/patients/{patientId}/allergies/{id}

# Patient Phone Numbers
GET    /api/patients/{patientId}/phones
POST   /api/patients/{patientId}/phones
PUT    /api/patients/{patientId}/phones
DELETE /api/patients/{patientId}/phones/{phoneId}

# Prescription Instructions
GET    /api/prescriptions/{prescriptionId}/instructions
POST   /api/prescriptions/{prescriptionId}/instructions
PUT    /api/prescriptions/{prescriptionId}/instructions/{instructionId}
DELETE /api/prescriptions/{prescriptionId}/instructions/{instructionId}
```

### Additional Resources
```
# Prescriptions
GET    /api/prescriptions/{id}                    # Get prescription
GET    /api/prescriptions/doctor                  # Doctor's prescriptions
GET    /api/prescriptions/patient                 # Patient's prescriptions
POST   /api/prescriptions                         # Create prescription (Doctor)
PUT    /api/prescriptions/{id}                    # Update prescription (Doctor)
DELETE /api/prescriptions/{id}                    # Delete prescription (Doctor)
PATCH  /api/prescriptions/{id}/status             # Update status (Doctor)

# Medical Histories
GET    /api/medicalhistories                      # List medical histories
GET    /api/medicalhistories/{id}                 # Get medical history
POST   /api/medicalhistories                      # Create record (Doctor)
PUT    /api/medicalhistories/{id}                 # Update record (Doctor)

# Documents
GET    /api/documents                             # List documents
GET    /api/documents/{id}                        # Get document details
POST   /api/documents                             # Upload document
PUT    /api/documents/{id}                        # Update document
GET    /api/documents/download/{id}               # Download file
DELETE /api/documents/{id}                        # Delete document

# Reviews
GET    /api/reviews/{doctorId}                    # Get doctor reviews
POST   /api/reviews                               # Create review (Patient)
PUT    /api/reviews/{id}                          # Update review (Patient)
DELETE /api/reviews/{id}                          # Delete review (Patient)

# System Data
GET    /api/medicines                             # List medicines
GET    /api/clinics                               # List clinics
GET    /api/specializations                       # List specializations
```

## 🔐 Authorization Roles

### Admin
- Full system access
- Manage doctors, patients, and clinics
- System configuration

### Doctor
- Access patient medical data
- Create/manage prescriptions and medical histories
- View and manage appointments
- Upload/manage medical documents

### Patient
- Access personal medical data
- Book and manage appointments
- View prescriptions and medical history
- Upload personal documents
- Create reviews for doctors

## 📋 Request/Response Format

### Authentication Response
```json
{
  "isAuthenticated": true,
  "message": "Success",
  "token": "jwt-token-here",
  "expiresOn": "2024-12-31T23:59:59Z",
  "roles": ["Patient"]
}
```

### Error Response
```json
{
  "statusCode": 404,
  "message": "Resource not found",
  "details": "Additional error information"
}
```

### Pagination Response
```json
{
  "pageIndex": 1,
  "pageSize": 10,
  "count": 25,
  "data": [...]
}
```

## 🛡️ Security Features

- **JWT Token Authentication** - Secure stateless authentication
- **Role-Based Authorization** - Granular access control
- **Resource Ownership** - Users can only access their own data
- **Input Validation** - DTO-based request validation
- **Error Handling** - Consistent error response format
- **File Security** - Secure document upload/download

## 🔍 Filtering & Pagination

Most list endpoints support filtering and pagination:
- `pageIndex` - Page number (1-based)
- `pageSize` - Items per page
- Entity-specific filters (dates, status, specialization, etc.)



## 🚦 Getting Started

1. **Authentication**: Register a user account or login to get a JWT token
2. **Authorization**: Include the JWT token in the `Authorization` header as `Bearer {token}`
3. **API Calls**: Make requests to the appropriate endpoints based on your role
4. **Error Handling**: Handle standardized error responses

## 📝 Notes

- All timestamps are in UTC format
- File uploads support multiple formats with size limitations
- Soft delete is implemented for most entities
- Audit trails are maintained for critical operations
- API follows RESTful conventions with proper HTTP status codes

## 🔧 Technical Stack

- **Framework**: ASP.NET Core
- **Authentication**: JWT Bearer tokens
- **Authorization**: Role-based with Claims
- **Validation**: Data Annotations & DTOs
- **Error Handling**: Global exception handling
- **Documentation**: Controller-level API documentation
