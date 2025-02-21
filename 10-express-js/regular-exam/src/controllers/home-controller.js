import { Router } from "express";

const controller = Router();

controller.get("/", (req, res) => {
  res.render("home/index");
});

export default controller;
