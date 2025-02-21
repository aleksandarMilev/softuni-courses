import express from "express";
import mongoose from "mongoose";
import cookieParser from "cookie-parser";
import handlebars from "express-handlebars";

import router from "./routes.js";
import { auth } from "./middlewares/auth-middleware.js";

const app = express();

try {
  await mongoose.connect("mongodb://localhost:27017/powerOfNature");
  console.log("DB connected!");
} catch (error) {
  console.log("Cannot connect to the DB!");
  console.log(error.message);
}

app.use(express.static("src/public"));
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(auth);
app.use(router);

app.use((req, res) => {
  res.status(404).render("home/404");
});

app.engine(
  "hbs",
  handlebars.engine({
    extname: "hbs",
    defaultLayout: "main",
    helpers: {
      eq: (a, b) => a === b,
    },
    runtimeOptions: {
      allowProtoMethodsByDefault: true,
      allowProtoPropertiesByDefault: true,
    },
  })
);

app.set("view engine", "hbs");
app.set("views", "./src/views");

const port = 3000;
app.listen(port, () => {
  console.log(`Server is now listening on port ${port}...`);
});
