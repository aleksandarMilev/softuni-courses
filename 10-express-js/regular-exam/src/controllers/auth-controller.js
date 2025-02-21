import { Router } from "express";

import { getErrorMessage } from "../common/functions.js";
import { isAuth, isGuest } from "../middlewares/auth-middleware.js";
import * as service from "../services/auth-service.js";

const controller = Router();

controller.get("/register", isGuest, (req, res) => {
  res.render("auth/register");
});

controller.get("/login", isGuest, (req, res) => {
  res.render("auth/login");
});

controller.post("/register", isGuest, async (req, res) => {
  const data = req.body;

  try {
    const token = await service.register(data);

    res.cookie("auth", token, { httpOnly: true });
    res.redirect("/");
  } catch (error) {
    res.render("auth/register", { error: getErrorMessage(error), user: data });
  }
});

controller.post("/login", isGuest, async (req, res) => {
  const data = req.body;

  try {
    const token = await service.login(data);

    res.cookie("auth", token, { httpOnly: true });
    res.redirect("/");
  } catch (error) {
    res.render("auth/login", { error: getErrorMessage(error), user: data });
  }
});

controller.get("/logout", isAuth, (req, res) => {
  res.clearCookie("auth");
  res.redirect("/");
});

export default controller;
