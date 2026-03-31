# KTBio API - Build and Run Script
# This script cleans, restores, builds and runs the API

Write-Host ""
Write-Host "=====================================================================" -ForegroundColor Cyan
Write-Host "                  KTBio API - Build & Run Script" -ForegroundColor Cyan
Write-Host "=====================================================================" -ForegroundColor Cyan
Write-Host ""

# Step 1: Kill any running instance
Write-Host "Step 1: Checking for running instances..." -ForegroundColor Yellow
$process = Get-Process -Name "KTBioAPI" -ErrorAction SilentlyContinue
if ($process) {
    Write-Host "  -> Stopping existing KTBioAPI process..." -ForegroundColor Red
    Stop-Process -Name "KTBioAPI" -Force
    Start-Sleep -Seconds 2
    Write-Host "  -> Process stopped" -ForegroundColor Green
} else {
    Write-Host "  -> No running instance found" -ForegroundColor Green
}

# Step 2: Clean
Write-Host ""
Write-Host "Step 2: Cleaning build artifacts..." -ForegroundColor Yellow
dotnet clean --verbosity quiet
if ($LASTEXITCODE -eq 0) {
    Write-Host "  -> Clean successful" -ForegroundColor Green
} else {
    Write-Host "  -> Clean failed!" -ForegroundColor Red
    exit 1
}

# Step 3: Restore packages
Write-Host ""
Write-Host "Step 3: Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore --verbosity quiet
if ($LASTEXITCODE -eq 0) {
    Write-Host "  -> Restore successful" -ForegroundColor Green
} else {
    Write-Host "  -> Restore failed!" -ForegroundColor Red
    exit 1
}

# Step 4: Build
Write-Host ""
Write-Host "Step 4: Building project..." -ForegroundColor Yellow
dotnet build --verbosity quiet --no-restore
if ($LASTEXITCODE -eq 0) {
    Write-Host "  -> Build successful" -ForegroundColor Green
} else {
    Write-Host "  -> Build failed!" -ForegroundColor Red
    Write-Host ""
    Write-Host "Run 'dotnet build' to see detailed error messages" -ForegroundColor Yellow
    exit 1
}

# Success message
Write-Host ""
Write-Host "=====================================================================" -ForegroundColor Cyan
Write-Host "                     Build Completed Successfully!" -ForegroundColor Green
Write-Host "=====================================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Default Login Credentials:" -ForegroundColor Yellow
Write-Host "  Username: admin" -ForegroundColor White
Write-Host "  Password: KTBio@2026" -ForegroundColor White
Write-Host ""
Write-Host "API Endpoints:" -ForegroundColor Yellow
Write-Host "  HTTP:    http://localhost:5000" -ForegroundColor White
Write-Host "  HTTPS:   https://localhost:5001" -ForegroundColor White
Write-Host "  Swagger: http://localhost:5000/swagger" -ForegroundColor White
Write-Host "  Health:  http://localhost:5000/health" -ForegroundColor White
Write-Host ""
Write-Host "=====================================================================" -ForegroundColor Cyan
Write-Host ""

# Step 5: Run
Write-Host "Starting API..." -ForegroundColor Green
Write-Host ""
dotnet run
