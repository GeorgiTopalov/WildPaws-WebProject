!/bin/bash 
# Run migrations
dotnet ef database update 
# Start the application
dotnet WildPaws.dll

