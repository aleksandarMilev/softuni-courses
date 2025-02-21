import jwtGenerator from "jsonwebtoken";
import { jwt as jwtConstants } from "../common/constants.js";

export const auth = (req, res, next) => {
  const token = req.cookies["auth"];

  if (!token) {
    return next();
  }

  try {
    const decodedToken = jwtGenerator.verify(token, jwtConstants.secret);

    req.user = decodedToken;
    res.locals.user = decodedToken;

    return next();
  } catch (error) {
    res.clearCookie("auth");
    return res.redirect("/auth/login");
  }
};

export const isAuth = (req, res, next) => {
  if (!req.user) {
    return res.redirect("/auth/login");
  }

  next();
};

export const isGuest = (req, res, next) => {
  if (req.user) {
    return res.redirect("/");
  }

  next();
};
