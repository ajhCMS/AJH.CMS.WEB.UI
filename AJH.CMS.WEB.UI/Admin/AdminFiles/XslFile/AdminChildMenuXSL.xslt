<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:UserControl="CMS:UserControl">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <xsl:call-template name="CreateMenu">
    </xsl:call-template>
  </xsl:template>
  <xsl:template name="CreateMenu">
    <xsl:variable name="CurrentModuleID">
      <xsl:choose>
        <xsl:when test="count(Menus/@ModuleID)>0">
          <xsl:value-of select="Menus/@ModuleID"/>
        </xsl:when>
        <xsl:otherwise>
          0
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="CurrentItemID">
      <xsl:choose>
        <xsl:when test="count(Menus/Menu [@Id=$CurrentModuleID])>0">
          <xsl:value-of select="$CurrentModuleID"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="Menus/Menu/@Id"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <div class="page-title">
      <span>
        <xsl:value-of select="Menus/Menu [@Id=$CurrentItemID]/@Name"/>
      </span>
    </div>
    <div class="holder">
      <ul id="ulMenuChildItems" class="scroll-pane left-menu">
        <xsl:apply-templates select="Menus/Menu [@Id=$CurrentItemID]/Menu [@Visible='true']">
        </xsl:apply-templates>
      </ul>
    </div>
  </xsl:template>
  <xsl:template match="Menu">
    <li class="left-menu-item">
      <a href="{UserControl:ResolveUrl(@Url)}?ModuleID={@ParentID}">
        <xsl:value-of select="@Name"/>
      </a>
    </li>
  </xsl:template>
</xsl:stylesheet>