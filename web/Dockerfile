# Use the official Node 16.14 image as the base image
FROM node:16.14


# Set the working directory inside the container
WORKDIR /app


# Copy package.json and package-lock.json to install dependencies
COPY package*.json ./


# Install app dependencies
RUN npm install


# Copy the rest of the app's source code to the container
COPY . .


# Build the React app
RUN npm run build


# Expose the port the app runs on
EXPOSE 3000


# Command to start the app - CMD instructions to run the app
CMD ["npm", "start"]