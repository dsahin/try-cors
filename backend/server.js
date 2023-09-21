'use strict';

// Constants
const PORT = 8081;
const HOST = '0.0.0.0';

const express = require('express');
const cookieParser = require('cookie-parser');

// App
const app = express();
app.use(cookieParser());

// Middleware to set CORS headers
app.use((req, res, next) => {
    res.header("Access-Control-Allow-Credentials", true);
    res.header("Access-Control-Allow-Origin", req.headers.origin); //'https://corsa.local'
    res.header(
      "Access-Control-Allow-Methods",
      "GET,PUT,POST,DELETE,UPDATE,OPTIONS"
    );
    res.header(
      "Access-Control-Allow-Headers",
      "X-Requested-With, X-HTTP-Method-Override, Content-Type, Accept, Authorization, Cookie"
    );
    next();
});

app.get('/set-cookie', (req, res) => {
    const cookieOptions = {
        httpOnly: true, // Cookie can't be accessed by JavaScript
        secure: true, // Send the cookie only over HTTPS
        sameSite: 'none', // Allow cross-site cookies
    };

    res.cookie('yourCookieName', 'yourCookieValue', cookieOptions);
    res.status(200).send('Cookie set successfully.');
});

app.get('/', (req, res) => {
  res.send('Hello World');
});

app.listen(PORT, HOST, () => {
  console.log(`Running on http://${HOST}:${PORT}`);
});