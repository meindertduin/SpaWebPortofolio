Running this application in Development:
    - cd ./ClientApp and install run: npm install
    - in root folder use run with: dotnet watch run 

Publishing Application:
    - 1 Docker build -t <ImageName> .
    - 2 Docker run -p 5000:80 -p 5001:443 <ImageName>

Environment variables dependent for production:
   - ClientSecret
   - AdminPassword
   - ConnectionStrings:SpaDatabase